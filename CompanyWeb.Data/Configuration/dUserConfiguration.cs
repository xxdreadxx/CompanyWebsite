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
    public class dUserConfiguration : IEntityTypeConfiguration<dUser>
    {
        public void Configure(EntityTypeBuilder<dUser> builder)
        {
            builder.ToTable("dUser");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).IsRequired(true).IsUnicode(true).HasMaxLength(50);
            builder.Property(x => x.Username).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
