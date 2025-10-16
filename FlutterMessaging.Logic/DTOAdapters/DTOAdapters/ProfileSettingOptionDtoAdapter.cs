using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

using FlutterMessaging.DTO.DTOAdapters.Interfaces;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class ProfileSettingOptionDtoAdapter(
        ProfileSettingOptionLogic profileSettingOptionLogic,
        IDTOMapper<ProfileSettingOption, ProfileSettingOptionRequest, ProfileSettingOptionResponse> mapper)
        : DtoLogicAdapter<ProfileSettingOption, ProfileSettingOptionRequest, ProfileSettingOptionResponse>(profileSettingOptionLogic, mapper),
          IProfileSettingOptionDtoAdapter
    {
    }
}
