using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.DTO.DTOAdapters.Interfaces
{
    public interface IExternalIdentityDtoAdapter
     : IDtoLogicAdapter<ExternalIdentityRequest, ExternalIdentityResponse>
    {
        Task<AuthTokenResponse> AuthenticateWithGoogle(string token, string nonce, string deviceId, CancellationToken cancellationToken);
        Task<AuthTokenResponse> RotateRefreshToken(Guid sessionId, string refreshToken, CancellationToken cancellationToken);
    }

}
