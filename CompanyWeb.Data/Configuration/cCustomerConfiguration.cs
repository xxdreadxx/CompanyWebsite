﻿using CompanyWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Configuration
{
    public class cCustomerConfiguration : IEntityTypeConfiguration<cCustomer>
    {
        public void Configure(EntityTypeBuilder<cCustomer> builder)
        {
            builder.ToTable("cCustomer");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Title).IsRequired(true).IsUnicode(true);
        }
    }
}
