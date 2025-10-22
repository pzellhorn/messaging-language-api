using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.Logic.Base.DTOAdapter;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class ExternalIdentityDtoAdapter(
    ExternalIdentityLogic externalIdentityLogic,
    IDTOMapper<ExternalIdentity, ExternalIdentityRequest, ExternalIdentityResponse> mapper)
    : DtoLogicAdapter<ExternalIdentity, ExternalIdentityRequest, ExternalIdentityResponse>(externalIdentityLogic, mapper),
      IExternalIdentityDtoAdapter
    {  

        public Task<AuthTokenResponse> AuthenticateWithGoogle(string token, string nonce, string deviceId, CancellationToken cancellationToken) 
            =>  externalIdentityLogic.AuthenticateWithGoogle(token, nonce, deviceId, cancellationToken);

        public Task<AuthTokenResponse> RotateRefreshToken(Guid sessionId, string refreshToken, CancellationToken cancellationToken)
          => externalIdentityLogic.RotateRefreshToken(sessionId, refreshToken, cancellationToken);
    }

}
