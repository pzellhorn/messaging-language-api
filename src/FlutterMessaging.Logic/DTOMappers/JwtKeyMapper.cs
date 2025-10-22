using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class JwtKeyMapper
        : IDTOMapper<JwtKey, JwtKeyRequest, JwtKeyResponse>
    {
        public Guid? ExtractId(JwtKeyRequest request) => request.JwtKeyId;

        public void ApplyRequestToModel(JwtKeyRequest request, JwtKey model)
        {
            model.Kid = (request.Kid ?? string.Empty).Trim();
            model.Alg = (request.Alg ?? string.Empty).Trim();
            model.PublicKeyPem = (request.PublicKeyPem ?? string.Empty).Trim();
            model.IsActive = request.IsActive;
            model.KeyVaultKeyId = (request.KeyVaultKeyId ?? string.Empty).Trim();
        }

        public JwtKey CreateEntity(JwtKeyRequest request)
        => new()
        {
                Kid = (request.Kid ?? string.Empty).Trim(),
                Alg = (request.Alg ?? string.Empty).Trim(),
                PublicKeyPem = (request.PublicKeyPem ?? string.Empty).Trim(),
                IsActive = request.IsActive,
                KeyVaultKeyId = (request.KeyVaultKeyId ?? string.Empty).Trim(),
        };

        public JwtKeyResponse ToResponse(JwtKey model)
        => new(model.JwtKeyId, model.Kid, model.Alg, model.PublicKeyPem, model.IsActive, model.KeyVaultKeyId);
    }
}
