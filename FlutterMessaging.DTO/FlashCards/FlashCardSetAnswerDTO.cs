using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.DTO.FlashCards
{ 
    public class FlashCardSetAnswerDTO
    {
        public Guid FlashCardAnswerId { get; set; } 
        public Guid FlashCardSetTemplateItemId { get; set; } 
        public Guid ProfileId { get; set; }   
        public string Answer { get; set; } = string.Empty;
    }
}
