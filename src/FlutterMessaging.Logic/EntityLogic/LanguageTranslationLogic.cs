using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.EntityLogic
{
    public class LanguageTranslationLogic(IBaseRepository<LanguageTranslation> languageTranslationRepository) : BaseLogic<LanguageTranslation>(languageTranslationRepository)
    {

    }
}
