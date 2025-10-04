using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FlutterMessaging.State.Base;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public partial class FlashCardAnswer : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<FlashCardAnswer> 
{
    public Guid FlashCardAnswerId { get; set; }

    public Guid FlashCardSetTemplateItemId { get; set; }

    public Guid ProfileId { get; set; }

    public string Answer { get; set; } = string.Empty;


    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }


    public static Expression<Func<FlashCardAnswer, Guid>> PrimaryKey => e => e.FlashCardAnswerId;


    public virtual FlashCardSetTemplateItem FlashCardSetTemplateItem { get; set; } 

    public virtual Profile Profile { get; set; } 
} 

internal sealed class FlashCardAnswerConfig : BaseConfig<FlashCardAnswer>
{
    public override void Configure(EntityTypeBuilder<FlashCardAnswer> entity)
    {
        base.Configure(entity);

        entity.ToTable("flash_card_answers");

        entity.HasOne(x => x.FlashCardSetTemplateItem)
           .WithMany(x => x.FlashCardAnswers)
           .HasForeignKey(x => x.FlashCardSetTemplateItemId);
         
        entity.HasOne(x => x.Profile)
           .WithMany(x => x.FlashCardAnswers)
           .HasForeignKey(x => x.ProfileId);
    }
}