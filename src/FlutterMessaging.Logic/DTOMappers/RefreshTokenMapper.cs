using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class RefreshTokenMapper
        : IDTOMapper<RefreshToken, RefreshTokenRequest, RefreshTokenResponse>
    {
        public Guid? ExtractId(RefreshTokenRequest request) => request.RefreshTokenId;

        public void ApplyRequestToModel(RefreshTokenRequest request, RefreshToken model)
        {
            model.SessionId = request.SessionId; model.TokenHash = (request.TokenHash ?? string.Empty).Trim(); model.TokenSalt = (request.TokenSalt ?? string.Empty).Trim(); model.ExpiresAt = request.ExpiresAt; model.RevokedAt = request.RevokedAt; model.ReplacedById = request.ReplacedById;
        }

        public RefreshToken CreateEntity(RefreshTokenRequest request)
        => new()
        {
                SessionId = request.SessionId, TokenHash = (request.TokenHash ?? string.Empty).Trim(), TokenSalt = (request.TokenSalt ?? string.Empty).Trim(), ExpiresAt = request.ExpiresAt, RevokedAt = request.RevokedAt, ReplacedById = request.ReplacedById,
        };

        public RefreshTokenResponse ToResponse(RefreshToken model)
        => new(model.RefreshTokenId, model.SessionId, model.TokenHash, model.TokenSalt, model.ExpiresAt, model.RevokedAt, model.ReplacedById);
    }
}
