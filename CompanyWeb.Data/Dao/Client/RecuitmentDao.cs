using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using X.PagedList;

namespace CompanyWeb.Data.Dao.Client
{
    public class RecuitmentDao
    {
        private readonly CompanyDbContext _context;

        public RecuitmentDao(CompanyDbContext context)
        {
            _context = context;
        }

        public sSystem? getRecuitmentCondition()
        {
            return _context.sSystems.FirstOrDefault();
        }

        public sSystem? getRecuitmentProcedure()
        {
            return _context.sSystems.FirstOrDefault();
        }

        public IEnumerable<dRecuitment> getRecuitmentPaging(int page, int pageSize)
        {
            var result = _context.dRecuitments.Where(x => x.Status == 1).OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
            return result;
        }

        public dRecuitment? getDetailRecuitment(int id)
        {
            return _context.dRecuitments.Where(x => x.ID == id).FirstOrDefault();
        }

        public List<dRecuitment> getNewRecuitments(int id)
        {
            return _context.dRecuitments.Where(x => x.Status == 1 && x.ID != id).OrderByDescending(x => x.CreatedDate).Take(6).ToList();
        }
    }
}