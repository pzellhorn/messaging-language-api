using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

using FlutterMessaging.DTO.DTOAdapters.Interfaces;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class JwtKeyDtoAdapter(
        JwtKeyLogic jwtKeyLogic,
        IDTOMapper<JwtKey, JwtKeyRequest, JwtKeyResponse> mapper)
        : DtoLogicAdapter<JwtKey, JwtKeyRequest, JwtKeyResponse>(jwtKeyLogic, mapper),
          IJwtKeyDtoAdapter
    {
    }
}
