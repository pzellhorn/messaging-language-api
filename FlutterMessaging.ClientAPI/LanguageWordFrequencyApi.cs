using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class LanguageWordFrequencyApi(ApiTransport api) : BaseClientApi<LanguageWordFrequencyRequest, LanguageWordFrequencyResponse>(api, "LanguageWordFrequency")
    {
    }
}
