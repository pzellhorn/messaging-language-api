using System.Linq.Expressions;
using pzellhorn.Core.State.Base;
using pzellhorn.Core.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public partial class FlashCardSetTemplateItem : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<FlashCardSetTemplateItem>
{
    public Guid FlashCardSetTemplateItemId { get; set; }

    public Guid FlashCardSetTemplateId { get; set; }

    public string Question { get; set; } = string.Empty;


    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }


    public static Expression<Func<FlashCardSetTemplateItem, Guid>> PrimaryKey => e => e.FlashCardSetTemplateItemId;


    public virtual List<FlashCardAnswer> FlashCardAnswers { get; set; } = new();

    public virtual FlashCardSetTemplate FlashCardSetTemplate { get; set; }

    public virtual List<FlashCardSetTemplateItemOption> FlashCardSetTemplateItemOptions { get; set; } = new();
} 

internal sealed class FlashCardSetTemplateItemConfig : BaseConfig<FlashCardSetTemplateItem>
{
    public override void Configure(EntityTypeBuilder<FlashCardSetTemplateItem> entity)
    {
        base.Configure(entity);

        entity.ToTable("flash_card_set_template_items");


        entity.HasMany(x => x.FlashCardAnswers)
           .WithOne(x => x.FlashCardSetTemplateItem)
           .HasForeignKey(x => x.FlashCardSetTemplateItemId);

        entity.HasOne(x => x.FlashCardSetTemplate)
          .WithMany(x => x.FlashCardSetTemplateItems)
          .HasForeignKey(x => x.FlashCardSetTemplateId);

        entity.HasMany(x => x.FlashCardSetTemplateItemOptions)
            .WithOne(x => x.FlashCardSetTemplateItem)
            .HasForeignKey(x => x.FlashCardSetTemplateItemId); 
    }
}