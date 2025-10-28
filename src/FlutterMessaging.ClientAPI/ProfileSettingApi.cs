using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class ProfileSettingApi(ApiTransport api) : BaseClientApi<ProfileSettingRequest, ProfileSettingResponse>(api, "ProfileSetting")
    {
    }
}
