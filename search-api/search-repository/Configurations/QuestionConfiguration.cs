using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using search_model;
using System;
using System.Collections.Generic;
using System.Text;

namespace search_data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x => x.IsActiveRegister).IsRequired();
            builder.Property(x => x.Statement).IsRequired();
            builder.Property(x => x.ThumbUrl).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.HasMany(x => x.Choices)
                    .WithOne(e => e.Question);
        }
    }
}
