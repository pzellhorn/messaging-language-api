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
    public class Language : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<Language>
    {
        public Guid LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
         
        public List<LanguageWordFrequency> LanguageWordFrequencies { get; set; } = new();

        public static Expression<Func<Language, Guid>> PrimaryKey => e => e.LanguageId;
    }

    internal sealed class LanguageConfig : BaseConfig<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> entity)
        {
            base.Configure(entity);

            entity.ToTable("Languages");

            entity.HasMany(x => x.LanguageWordFrequencies)
                .WithOne(x => x.Language)
                .HasForeignKey(x => x.LanguageId);
        }
    }
}
