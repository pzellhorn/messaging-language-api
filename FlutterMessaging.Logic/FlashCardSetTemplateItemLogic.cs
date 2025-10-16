using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic
{
    public class FlashCardSetTemplateItemLogic(IBaseRepository<FlashCardSetTemplateItem> flashCardSetTemplateItemRepository) : BaseLogic<FlashCardSetTemplateItem>(flashCardSetTemplateItemRepository)
    {

    }
}
