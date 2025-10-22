using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class ProfileSettingOptionApi(ApiTransport api) : BaseClientApi<ProfileSettingOptionRequest, ProfileSettingOptionResponse>(api, "ProfileSettingOption")
    {
    }
}
