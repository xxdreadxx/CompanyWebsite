using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using X.PagedList;

namespace CompanyWeb.Data.Dao.Client
{
    public class FeedBackDao
    {
        private readonly CompanyDbContext _context;

        public FeedBackDao(CompanyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<dFeedback> getFeedBackPaging(int page, int pageSize)
        {
            var result = _context.dFeedbacks.Where(x => x.Status == 1).OrderByDescending(x => x.Star).ToPagedList(page, pageSize);
            return result;
        }
    }
}