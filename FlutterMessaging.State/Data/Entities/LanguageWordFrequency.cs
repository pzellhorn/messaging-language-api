using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FlutterMessaging.State.Base;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public partial class LanguageWordFrequency : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<LanguageWordFrequency> 
{
    public Guid LanguageWordFrequencyId { get; set; }

    public Guid LanguageId { get; set; }

    public Guid LanguageTranslationId { get; set; }

    public int FrequencyRank { get; set; }


    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }


    public static Expression<Func<LanguageWordFrequency, Guid>> PrimaryKey => e => e.LanguageWordFrequencyId;

     
    public virtual Language Language { get; set; } = null!;
} 

internal sealed class LanguageWordFrequencyConfig : BaseConfig<LanguageWordFrequency>
{
    public override void Configure(EntityTypeBuilder<LanguageWordFrequency> entity)
    {
        base.Configure(entity);

        entity.ToTable("language_word_frequencies");

        entity.HasOne(x => x.Language)
        .WithMany(x => x.LanguageWordFrequencies)
        .HasForeignKey(x => x.LanguageId);
    }
}