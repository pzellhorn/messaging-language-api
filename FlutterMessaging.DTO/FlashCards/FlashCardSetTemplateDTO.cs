using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.DTO.FlashCards
{
    public class FlashCardSetTemplateDTO
    {
        public Guid FlashCardSetTemplateId { get; set; }

        public string FlashCardSetName { get; set; } = string.Empty;
        public int FlashCardType { get; set; }    
    } 
}
