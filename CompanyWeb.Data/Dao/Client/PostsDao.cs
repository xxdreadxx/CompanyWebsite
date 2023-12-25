using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWeb.Data.Dao.Client
{
    public class PostsDao
    {
        private readonly CompanyDbContext _context;

        public PostsDao(CompanyDbContext context)
        {
            _context = context;
        }

        public List<dPost> getAlldPostsByCategory(int categoryID = 0)
        {
            return _context.dPosts.Where(x => x.Status == 1 && x.ID_CPost == categoryID).ToList();
        }
    }
}