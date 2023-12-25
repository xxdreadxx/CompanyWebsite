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
    public class dQnAConfiguration : IEntityTypeConfiguration<dQnA>
    {
        public void Configure(EntityTypeBuilder<dQnA> builder)
        {
            builder.ToTable("dQnA");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Question).IsUnicode(true);
            builder.Property(x => x.Answer).IsUnicode(true);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
