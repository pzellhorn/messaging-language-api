using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FlutterMessaging.State.Data.Entities
{

    public partial class FlashCardSetTemplateItemOption : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<FlashCardSetTemplateItemOption>
    {
        public Guid FlashCardSetTemplateItemOptionId { get; set; }

        public Guid FlashCardSetTemplateItemId { get; set; }

        public string OptionKey { get; set; } = string.Empty;

        public string OptionValue { get; set; } = string.Empty;


        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }


        public static Expression<Func<FlashCardSetTemplateItemOption, Guid>> PrimaryKey => e => e.FlashCardSetTemplateItemOptionId;


        public virtual FlashCardSetTemplateItem FlashCardSetTemplateItem { get; set; } = null;

    }

    internal sealed class FlashCardSetTemplateItemOptionConfig : BaseConfig<FlashCardSetTemplateItemOption>
    {
        public override void Configure(EntityTypeBuilder<FlashCardSetTemplateItemOption> entity)
        {
            base.Configure(entity);

            entity.ToTable("flash_card_set_template_item_options");


            entity.HasOne(x => x.FlashCardSetTemplateItem)
               .WithMany(x => x.FlashCardSetTemplateItemOptions)
               .HasForeignKey(x => x.FlashCardSetTemplateItemId);
        }
    }
}
