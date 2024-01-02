using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using X.PagedList;

namespace CompanyWeb.Data.Dao.Client
{
    public class CustomerDao
    {
        private readonly CompanyDbContext _context;

        public CustomerDao(CompanyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<dCustomer> getAllCustomer(int id, int page, int pageSize)
        {
            var result = _context.dCustomers.Where(x => x.Status == 1 && x.ID_CCustomer == id).OrderByDescending(x => x.Title).ToPagedList(page, pageSize);
            return result;
        }
    }
}