using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;

namespace FlutterMessaging.DTO.DTOAdapters.Interfaces
{
    public interface IExternalIdentityDtoAdapter
     : IDtoLogicAdapter<ExternalIdentityRequest, ExternalIdentityResponse>
    {
        Task<string> AuthenticateWithGoogle(string token, string nonce, string deviceId, CancellationToken cancellationToken);
    }

}
