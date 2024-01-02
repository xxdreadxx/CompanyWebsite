using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using X.PagedList;

namespace CompanyWeb.Data.Dao.Client
{
    public class PostsDao
    {
        private readonly CompanyDbContext _context;

        public PostsDao(CompanyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<dPost> getAlldPostsByCategory(int categoryID, int page, int pageSize)
        {
            var result = _context.dPosts.Where(x => x.Status == 1 && x.ID_CPost == categoryID).OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
            return result;
        }

        public List<dPost> getAllPost()
        {
            return _context.dPosts.Where(x => x.Status == 1).ToList();
        }

        public dPost? getPostById(int id)
        {
            return _context.dPosts.Where(x => x.ID == id).FirstOrDefault();
        }

        public List<dPost> getRecentPosts(int id)
        {
            int? categoryId = 0;
            var getIdCategory = _context.dPosts.Where(x => x.ID == id).FirstOrDefault();
            if (getIdCategory != null)
            {
                categoryId = getIdCategory.ID_CPost;
            }
            return _context.dPosts.Where(x => x.ID_CPost == categoryId && x.ID != id).OrderByDescending(x => x.CreatedDate).Take(5).ToList();
        }

        public cPost? getCategoryById(int id)
        {
            int? categoryId = 0;
            var getIdCategory = _context.dPosts.Where(x => x.ID == id).FirstOrDefault();
            if (getIdCategory != null)
            {
                categoryId = getIdCategory.ID_CPost;
            }
            return _context.cPosts.Where(x => x.ID == categoryId).FirstOrDefault();
        }
    }
}