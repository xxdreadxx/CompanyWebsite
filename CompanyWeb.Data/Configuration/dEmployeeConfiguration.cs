using CompanyWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Configuration
{
    public class dEmployeeConfiguration : IEntityTypeConfiguration<dEmployee>
    {
        public void Configure(EntityTypeBuilder<dEmployee> builder)
        {
            builder.ToTable("dEmployee");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).IsRequired(true).IsUnicode(true).HasMaxLength(50);
            builder.Property(x => x.ExperienceYear).IsUnicode(true).HasMaxLength(200);
            builder.Property(x => x.Position).IsUnicode(true);
            builder.Property(x => x.Content).IsUnicode(true);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
