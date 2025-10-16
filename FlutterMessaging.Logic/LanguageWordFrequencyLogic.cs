using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic
{
    public class LanguageWordFrequencyLogic(IBaseRepository<LanguageWordFrequency> languageWordFrequencyRepository) : BaseLogic<LanguageWordFrequency>(languageWordFrequencyRepository)
    {

    }
}
