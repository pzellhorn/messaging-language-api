using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FlutterMessaging.State.Base;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public partial class LanguageTranslation : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<LanguageTranslation> 
{
    public Guid LanguageTranslationId { get; set; } 

    public Guid FromLanguageId { get; set; }

    public Guid ToLanguageId { get; set; }

    public string FromLanguageText { get; set; } = null!;

    public string ToLanguageText { get; set; } = null!;


    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }


    public static Expression<Func<LanguageTranslation, Guid>> PrimaryKey => e => e.LanguageTranslationId;

     
    public virtual Language Langauge { get; set; } 
} 

internal sealed class LanguageTranslationConfig : BaseConfig<LanguageTranslation>
{
    public override void Configure(EntityTypeBuilder<LanguageTranslation> entity)
    {
        base.Configure(entity);

        entity.ToTable("language_translations"); 
    }
}