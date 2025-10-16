using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic
{
    public class LanguageTranslationLogic(IBaseRepository<LanguageTranslation> languageTranslationRepository) : BaseLogic<LanguageTranslation>(languageTranslationRepository)
    {

    }
}
