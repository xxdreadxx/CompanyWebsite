using CompanyWeb.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Configuration
{
    public class dFeedbackConfiguration : IEntityTypeConfiguration<dFeedback>
    {
        public void Configure(EntityTypeBuilder<dFeedback> builder)
        {
            builder.ToTable("dFeedback");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).IsRequired(true).IsUnicode(true).HasMaxLength(50);
            builder.Property(x => x.Content).IsUnicode(true);
        }
    }
}
