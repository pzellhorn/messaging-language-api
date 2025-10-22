using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class ProfileDtoAdapter(
        ProfileLogic profileLogic,
        IDTOMapper<Profile, ProfileRequest, ProfileResponse> mapper)
        : DtoLogicAdapter<Profile, ProfileRequest, ProfileResponse>(profileLogic, mapper),
          IProfileDtoAdapter
    {
    }
}
