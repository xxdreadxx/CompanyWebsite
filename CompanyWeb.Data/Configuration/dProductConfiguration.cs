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
    public class dProductConfiguration : IEntityTypeConfiguration<dProduct>
    {
        public void Configure(EntityTypeBuilder<dProduct> builder)
        {
            builder.ToTable("dProduct");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Image).IsUnicode(true);
            builder.Property(x => x.Content).IsUnicode(true);
            builder.Property(x => x.Description).IsUnicode(true);
            builder.Property(x => x.Title).IsUnicode(true);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
