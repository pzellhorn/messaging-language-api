using System.Linq.Expressions;
using pzellhorn.Core.State.Base;
using pzellhorn.Core.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public partial class FlashCardSetTemplate : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<FlashCardSetTemplate> 
{
    public Guid FlashCardSetTemplateId { get; set; }

    public string FlashCardSetName { get; set; } = string.Empty; 
    public int FlashCardType { get; set; }


    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; } 

    public static Expression<Func<FlashCardSetTemplate, Guid>> PrimaryKey => e => e.FlashCardSetTemplateId;


    public virtual List<FlashCardSetTemplateItem> FlashCardSetTemplateItems { get; set; } = new();
} 

internal sealed class FlashCardSetTemplateConfig : BaseConfig<FlashCardSetTemplate>
{
    public override void Configure(EntityTypeBuilder<FlashCardSetTemplate> entity)
    {
        base.Configure(entity);

        entity.ToTable("flash_card_set_templates");

        entity.HasMany(x => x.FlashCardSetTemplateItems)
        .WithOne(x => x.FlashCardSetTemplate)
        .HasForeignKey(x => x.FlashCardSetTemplateId);
    }
}