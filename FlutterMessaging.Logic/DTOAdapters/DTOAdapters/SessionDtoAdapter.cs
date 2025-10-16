using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

using FlutterMessaging.DTO.DTOAdapters.Interfaces;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class SessionDtoAdapter(
        SessionLogic sessionLogic,
        IDTOMapper<Session, SessionRequest, SessionResponse> mapper)
        : DtoLogicAdapter<Session, SessionRequest, SessionResponse>(sessionLogic, mapper),
          ISessionDtoAdapter
    {
    }
}
