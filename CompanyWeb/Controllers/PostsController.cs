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

        public ActionResult Index(int id = 0, int page = 1, int pageSize = 6)
        {
            var dao = new PostsDao(_context);
            var daoCategoriesPost = new LayoutDao(_context);
            ViewBag.categoryPosts = daoCategoriesPost.getAllCategories();
            ViewBag.lstPostsPaging = dao.getAlldPostsByCategory(id, page, pageSize);

            return View();
        }

        public ActionResult Detail(int id)
        {
            var dao = new PostsDao(_context);
            var daoCategoriesPost = new LayoutDao(_context);
            ViewBag.categoryPosts = daoCategoriesPost.getAllCategories();
            ViewBag.detailPost = dao.getPostById(id);
            ViewBag.category = dao.getCategoryById(id);
            ViewBag.lstAllPost = dao.getAllPost();
            ViewBag.lstRecentPosts = dao.getRecentPosts(id);

            return View(id);
        }
    }
}