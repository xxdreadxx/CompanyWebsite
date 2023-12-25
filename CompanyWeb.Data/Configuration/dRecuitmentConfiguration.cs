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
    public class dRecuitmentConfiguration : IEntityTypeConfiguration<dRecuitment>
    {
        public void Configure(EntityTypeBuilder<dRecuitment> builder)
        {
            builder.ToTable("dRecuitment");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Title).IsUnicode(true).HasMaxLength(100);
            builder.Property(x => x.Content).IsUnicode(true);
            builder.Property(x => x.Requirement).IsUnicode(true);
            builder.Property(x => x.FromDate).IsUnicode(true);
            builder.Property(x => x.ToDate).IsUnicode(true);
            builder.Property(x => x.Treatment).IsUnicode(true);
            builder.Property(x => x.WorkAddress).IsUnicode(true);
            builder.Property(x => x.WorkPosition).IsUnicode(true);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
