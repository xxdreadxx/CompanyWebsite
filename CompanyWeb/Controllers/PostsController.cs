using CompanyWeb.Data.Dao.Client;
using CompanyWeb.Data.EF;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Controllers
{
    public class PostsController : Controller
    {
        private readonly CompanyDbContext _context;

        public PostsController(CompanyDbContext context)
        {
            _context = context;
        }
        public ActionResult Index(int id = 0)
        {
            var dao = new PostsDao(_context);
            ViewBag.lstPosts = dao.getAlldPostsByCategory(id);

            return View();
        }
    }
}
