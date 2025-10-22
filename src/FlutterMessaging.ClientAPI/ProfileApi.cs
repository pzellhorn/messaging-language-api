using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class ProfileApi(ApiTransport api) : BaseClientApi<ProfileRequest, ProfileResponse>(api, "Profile")
    {
    }
}
