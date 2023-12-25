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
    public class dPostConfiguration : IEntityTypeConfiguration<dPost>
    {
        public void Configure(EntityTypeBuilder<dPost> builder)
        {
            builder.ToTable("dPost");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Title).IsRequired(true).IsUnicode(true);
            builder.Property(x => x.Description).IsUnicode(true).HasMaxLength(200);
            builder.Property(x => x.Content).IsUnicode(true);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
