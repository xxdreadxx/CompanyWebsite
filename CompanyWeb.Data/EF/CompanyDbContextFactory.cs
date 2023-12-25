using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.EF
{
    public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
    {
        public CompanyDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuaration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionstring = configuaration.GetConnectionString("CompanyDb");
            var optionsBuilder = new DbContextOptionsBuilder<CompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            return new CompanyDbContext(optionsBuilder.Options);
        }
    }
}
