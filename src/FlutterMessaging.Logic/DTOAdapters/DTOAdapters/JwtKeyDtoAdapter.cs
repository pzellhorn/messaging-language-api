using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.Logic.Base.DTOAdapter;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.State.Data.Entities;

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
