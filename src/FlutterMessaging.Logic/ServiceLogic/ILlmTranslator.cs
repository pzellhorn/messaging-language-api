using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.DTO.RequestDTOs.MessagingRequests;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;

namespace FlutterMessaging.Logic.ServiceLogic
{
    public interface ILlmTranslator
    {
        LLMTranslationResponse Translate(LLMTranslationRequest translator);
    }
}
