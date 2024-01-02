using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;

namespace CompanyWeb.Data.Dao.Client
{
    public class HomeDao
    {
        private readonly CompanyDbContext _context;

        public HomeDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<cProduct> getAllcProduct()
        {
            return _context.cProducts.Where(x => x.Status == 1).ToList();
        }

        public List<dProduct> getNewdProduct()
        {
            return _context.dProducts.Where(x => x.Status == 1).OrderByDescending(x => x.CreatedDate).Take(6).ToList();
        }

        public List<dProduct> getProductStatic()
        {
            return _context.dProducts.Where(x => x.Status == 1 && x.ID_CProduct == 3).OrderByDescending(x => x.CreatedDate).Take(4).ToList();
        }

        public List<dCustomer> getCustomer()
        {
            return _context.dCustomers.Where(x => x.Status == 1 && x.ID_CCustomer == 1).Take(4).ToList();
        }

        public List<dFeedback> getRandomFeedBack()
        {
            var rnd = new Random();
            List<dFeedback> result = _context.dFeedbacks.Where(x => x.Status == 1).OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            return result;
        }

        public List<dPost> getPots()
        {
            return _context.dPosts.Where(x => x.Status == 1).OrderByDescending(x => x.CreatedDate).Take(3).ToList();
        }
    }
}