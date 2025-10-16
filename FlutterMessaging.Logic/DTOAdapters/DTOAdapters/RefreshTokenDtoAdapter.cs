using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class RefreshTokenDtoAdapter(
        RefreshTokenLogic refreshTokenLogic,
        IDTOMapper<RefreshToken, RefreshTokenRequest, RefreshTokenResponse> mapper)
        : DtoLogicAdapter<RefreshToken, RefreshTokenRequest, RefreshTokenResponse>(refreshTokenLogic, mapper),
          IRefreshTokenDtoAdapter
    {
    }
}
