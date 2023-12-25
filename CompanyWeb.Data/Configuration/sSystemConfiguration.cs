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
    public class sSystemConfiguration : IEntityTypeConfiguration<sSystem>
    {
        public void Configure(EntityTypeBuilder<sSystem> builder)
        {
            builder.ToTable("sSystem");
            builder.HasKey(x => x.ID);
        }
    }
}
