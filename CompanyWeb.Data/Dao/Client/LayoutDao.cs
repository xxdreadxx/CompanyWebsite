using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;

namespace CompanyWeb.Data.Dao.Client
{
    public class LayoutDao
    {
        private readonly CompanyDbContext _context;

        public LayoutDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<cPost> getAllCategories()
        {
            return _context.cPosts.Where(x => x.Status == 1).ToList();
        }
    }
}