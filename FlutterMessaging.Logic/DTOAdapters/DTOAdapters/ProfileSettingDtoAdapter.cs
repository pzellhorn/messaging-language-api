using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

using FlutterMessaging.DTO.DTOAdapters.Interfaces;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class ProfileSettingDtoAdapter(
        ProfileSettingLogic profileSettingLogic,
        IDTOMapper<ProfileSetting, ProfileSettingRequest, ProfileSettingResponse> mapper)
        : DtoLogicAdapter<ProfileSetting, ProfileSettingRequest, ProfileSettingResponse>(profileSettingLogic, mapper),
          IProfileSettingDtoAdapter
    {
    }
}
