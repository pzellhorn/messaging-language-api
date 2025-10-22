using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.EntityLogic
{
    public class FlashCardSetTemplateItemLogic(IBaseRepository<FlashCardSetTemplateItem> flashCardSetTemplateItemRepository) : BaseLogic<FlashCardSetTemplateItem>(flashCardSetTemplateItemRepository)
    {

    }
}
