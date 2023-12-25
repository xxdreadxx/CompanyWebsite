using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Client
{
    public class AboutDao
    {
        private readonly CompanyDbContext _context;

        public AboutDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<dEmployee> getAlldEmployee()
        {
            return _context.dEmployees.Where(x => x.Status == 1).ToList();
        }

        public sSystem? getData()
        {
            return _context.sSystems.FirstOrDefault();
        }
    }
}