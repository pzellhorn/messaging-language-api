using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.ClientAPI
{
    public class RefreshTokenApi(ApiTransport api) : BaseClientApi<RefreshTokenRequest,RefreshTokenResponse>(api, "RefreshToken")
    {
    }
}
