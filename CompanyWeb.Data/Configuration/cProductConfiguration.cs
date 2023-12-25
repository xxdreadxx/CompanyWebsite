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
    public class cProductConfiguration : IEntityTypeConfiguration<cProduct>
    {
        public void Configure(EntityTypeBuilder<cProduct> builder)
        {
            builder.ToTable("cProduct");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Title).IsRequired(true).IsUnicode(true).HasMaxLength(100);
        }
    }
}
