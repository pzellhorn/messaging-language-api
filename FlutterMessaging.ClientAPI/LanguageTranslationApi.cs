using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.ClientAPI
{
    public class LanguageTranslationApi(ApiTransport api) : BaseClientApi<LanguageTranslation>(api, "LanguageTranslation")
    {
    }
}
