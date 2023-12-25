using CompanyWeb.Data.Configuration;
using CompanyWeb.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.EF
{
    public class CompanyDbContext : IdentityDbContext
    {
        public CompanyDbContext(DbContextOptions options) : base(options)
        {
            //options.UseQslServer("")
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration
            //add-migration <name of migration>
            //remove-migration
            //update-database
            modelBuilder.ApplyConfiguration(new cCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new cPostConfiguration());
            modelBuilder.ApplyConfiguration(new cProductConfiguration());
            modelBuilder.ApplyConfiguration(new dCustomerConfiguartion());
            modelBuilder.ApplyConfiguration(new dEmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new dFeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new dPostConfiguration());
            modelBuilder.ApplyConfiguration(new dProductConfiguration());
            modelBuilder.ApplyConfiguration(new dQnAConfiguration());
            modelBuilder.ApplyConfiguration(new dRecuitmentConfiguration());
            modelBuilder.ApplyConfiguration(new dUserConfiguration());
            modelBuilder.ApplyConfiguration(new sSystemConfiguration());

            base.OnModelCreating(modelBuilder);
            //Data seeding
            modelBuilder.Entity<dUser>().HasData(new dUser { ID = 1, Name = "Quản trị viên", Username = "admin", Password = "123$%^", CreatedDate = DateTime.Now, Status = 1 });
        }

        public static Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }

        public DbSet<cProduct> cProducts { get; set; }
        public DbSet<cPost> cPosts { get; set; }
        public DbSet<cCustomer> cCustomers { get; set; }
        public DbSet<dQnA> dQnAs { get; set; }
        public DbSet<dProduct> dProducts { get; set; }
        public DbSet<dPost> dPosts { get; set; }
        public DbSet<dCustomer> dCustomers { get; set; }
        public DbSet<dRecuitment> dRecuitments { get; set; }
        public DbSet<dFeedback> dFeedbacks { get; set; }
        public DbSet<dEmployee> dEmployees { get; set; }
        public DbSet<sSystem> sSystems { get; set; }
        public DbSet<dUser> dUsers { get; set; }
    }
}
