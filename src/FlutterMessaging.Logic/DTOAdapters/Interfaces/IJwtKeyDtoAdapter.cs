using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.DTO.DTOAdapters.Interfaces
{
    public interface IJwtKeyDtoAdapter
        : IDtoLogicAdapter<JwtKeyRequest, JwtKeyResponse>
    {
    }
}
