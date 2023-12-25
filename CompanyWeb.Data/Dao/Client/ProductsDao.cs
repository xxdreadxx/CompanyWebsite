using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;

namespace CompanyWeb.Data.Dao.Client
{
    public class ProductsDao
    {
        private readonly CompanyDbContext _context;

        public ProductsDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<cProduct> getCategory()
        {
            return _context.cProducts.Where(x => x.Status == 1).ToList();
        }

        public List<dProduct> getAllProduct()
        {
            return _context.dProducts.Where(x => x.Status == 1).ToList();
        }
    }
}