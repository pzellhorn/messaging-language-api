using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.DTO.FlashCards
{ 
    public class FlashCardSetItemOptionDTO
    {
        public Guid FlashCardSetTemplateItemOptionId { get; set; } 
        public Guid FlashCardSetTemplateItemId { get; set; } 
        public string OptionKey { get; set; } = string.Empty; 
        public string OptionValue { get; set; } = string.Empty;

    }
}
