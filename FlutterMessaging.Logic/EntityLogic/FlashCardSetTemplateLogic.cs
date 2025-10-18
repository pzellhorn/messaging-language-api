using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.EntityLogic
{
    public class FlashCardSetTemplateLogic(IBaseRepository<FlashCardSetTemplate> flashCardSetRepository) : BaseLogic<FlashCardSetTemplate>(flashCardSetRepository)
    {
        public Task UpsertFlashCardSet(CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
