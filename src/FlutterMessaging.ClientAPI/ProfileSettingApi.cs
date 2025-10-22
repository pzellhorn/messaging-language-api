using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class ProfileSettingApi(ApiTransport api) : BaseClientApi<ProfileSettingRequest, ProfileSettingResponse>(api, "ProfileSetting")
    {
    }
}
