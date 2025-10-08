using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.DTO.FlashCards
{ 
    public class FlashCardSetTemplateItemDTO
    {
        public Guid FlashCardSetTemplateItemId { get; set; } 
        public Guid FlashCardSetTemplateId { get; set; } 
        public string Question { get; set; } = string.Empty;
    }
}
