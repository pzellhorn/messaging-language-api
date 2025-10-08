using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic
{
    public class FlashCardSetTemplateLogic(IBaseRepository<FlashCardSetTemplate> flashCardSetRepository) : BaseLogic<FlashCardSetTemplate>(flashCardSetRepository)
    {
        public Task UpsertFlashCardSet(CancellationToken cancellationToken)
        {
            return default;
        }
    }
} 
 