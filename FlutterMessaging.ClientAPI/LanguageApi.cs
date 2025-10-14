using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.ClientAPI
{
    public class LanguageApi(ApiTransport api) : BaseClientApi<Language>(api, "Language")
    {
    }
}
