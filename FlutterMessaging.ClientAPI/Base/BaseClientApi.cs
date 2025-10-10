using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FlutterMessaging.ClientAPI.Types;

namespace FlutterMessaging.ClientAPI.Base
{
    public abstract class BaseClientApi<T>(ApiTransport api, string controllerSegment) : IBaseClientApi<T> where T : class
    {     
        protected virtual string BasePath => $"api/{controllerSegment}";
        protected virtual JsonSerializerOptions Json => api.JsonOptions;

        protected virtual string ActionUrl(string action, params (string Key, string? Value)[] query)
        {
            var baseUrl = $"{BasePath}/{action}";
            if (query is null || query.Length == 0) return baseUrl;

            var qs = string.Join("&",
                query.Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                     .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value!)}"));

            return string.IsNullOrEmpty(qs) ? baseUrl : $"{baseUrl}?{qs}";
        }

        public Task<T> Upsert(T entity, CancellationToken cancellationToken = default)
          => Post<T, T>(nameof(Upsert), entity, cancellationToken);

        protected Task<TResult> Post<TResult>(string action, CancellationToken cancellationToken = default, params (string Key, string? Value)[] query)
            => api.Post<TResult>(ActionUrl(action, query), cancellationToken);

        protected Task<TResult> Post<TRequest, TResult>(string action, TRequest body, CancellationToken cancellationToken = default, params (string Key, string? Value)[] query)
            => api.Post<TRequest, TResult>(ActionUrl(action, query), body, cancellationToken);
          
        public Task<T?> Get(Guid id, CancellationToken cancellationToken = default)
            => api.Get<T?>(ActionUrl(nameof(Get), ("id", id.ToString())), cancellationToken);  

        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage resp = await api.Delete(ActionUrl(nameof(Delete), ("id", id.ToString())), cancellationToken);
            if (resp.StatusCode == HttpStatusCode.NoContent) return true;
            if (resp.StatusCode == HttpStatusCode.NotFound) return false;
            resp.EnsureSuccessStatusCode();
            return true;
        }
    }
} 
