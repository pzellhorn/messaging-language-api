using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class ProfileSettingOptionApi(ApiTransport api) : BaseClientApi<ProfileSettingOptionRequest, ProfileSettingOptionResponse>(api, "ProfileSettingOption")
    {
    }
}
