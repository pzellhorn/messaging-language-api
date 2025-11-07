using System.Text;
using System.Text.Json;
using FlutterMessaging.DTO.RequestDTOs.MessagingRequests;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;

namespace FlutterMessaging.Logic.ServiceLogic
{
    public class LlmTranslator(HttpClient http) : ILlmTranslator
    {
        private const string _googleGeminiEndpoint = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent";

        private readonly string _apiKey = Environment.GetEnvironmentVariable("GoogleAPIKey") ??
          throw new InvalidOperationException("Gemini API key not configured.");

        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = null
        };

        public LLMTranslationResponse Translate(LLMTranslationRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrWhiteSpace(request.MessageToTranslate))
                return new LLMTranslationResponse { Message = string.Empty };

            string systemInstruction = BuildSystemInstruction(request.FromLanguage, request.ToLanguage);

            string userPrompt = BuildTranslationPrompt(request.ToLanguage, request.MessageToTranslate, request.MessageContext);


            var body = new
            {
                contents = new[]
            {
                new
                { 
                    parts = new[] { new { text = userPrompt } }
                }
            },
                systemInstruction = new
                {
                    role = "system",
                    parts = new[] { new { text = systemInstruction } }
                },
                generationConfig = new
                {
                    temperature = 0.2
                }
            };

            HttpRequestMessage httpReq = new (HttpMethod.Post, _googleGeminiEndpoint)
            {
                Content = new StringContent(JsonSerializer.Serialize(body, _jsonOptions),
                                            Encoding.UTF8, "application/json")
            };

            httpReq.Headers.Add("x-goog-api-key", _apiKey);

            try
            {
                HttpResponseMessage httpResp = http.SendAsync(httpReq).GetAwaiter().GetResult();
                string raw = httpResp.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (!httpResp.IsSuccessStatusCode)
                {
                    return new LLMTranslationResponse
                    {
                        Message = $"[translation_error {((int)httpResp.StatusCode)}] {raw}"
                    };
                }

                JsonDocument doc = JsonDocument.Parse(raw);
                if (doc.RootElement.TryGetProperty("candidates", out JsonElement candidates) &&
                    candidates.GetArrayLength() > 0 &&
                    candidates[0].TryGetProperty("content", out JsonElement content) &&
                    content.TryGetProperty("parts", out JsonElement parts) &&
                    parts.GetArrayLength() > 0 &&
                    parts[0].TryGetProperty("text", out JsonElement textElement))
                {
                    string text = textElement.GetString() ?? string.Empty;
                    return new LLMTranslationResponse { Message = text.Trim() };
                }
                else
                {
                    return new LLMTranslationResponse
                    {
                        Message = $"translation_exception: Failed to decode translation"
                    };
                }
            }
            catch (Exception ex)
            {
                return new LLMTranslationResponse
                {
                    Message = $"[translation_exception] {ex.Message}"
                };
            }
        }

        private static string BuildTranslationPrompt(string toLanguage, string message, string? sentenceContext)
        {
            string text = $"Translate the following Message Text into {toLanguage}.\n" +
                $"Preserve meaning, tone, names, punctuation, emojis, and line breaks.\n" +
                $"If it already appears to be {toLanguage}, return it unchanged.\n";

            if (sentenceContext != null)
                text += $"Sentence context around this message is: \"{sentenceContext}\" \n";

            text += $"Output only the translated Message Text (no preface, no language labels, no context):\n\n" +
           $"\"\"\"\n{message}\n\"\"\"";
            return text;
        }

        private static string BuildSystemInstruction(string fromLanguage, string targetLanguage)
        {
            return
                $"You are a precise, professional translator that always translates from {fromLanguage} into {targetLanguage}. " +
                $"Preserve semantics, tone, names, punctuation, markdown, URLs, emojis, and whitespace. " +
                $"Never add notes, brackets, or explanations. Never redact.";
        }
    }
}
