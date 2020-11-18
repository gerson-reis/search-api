using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using search_model;
using System;
using System.Collections.Generic;
using System.Text;

namespace search_data.Configurations
{
    public class QuestionChoiceConfiguration : IEntityTypeConfiguration<QuestionChoice>
    {
        public void Configure(EntityTypeBuilder<QuestionChoice> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.IsActiveRegister).IsRequired();
            builder.Property(x => x.Votes).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}
