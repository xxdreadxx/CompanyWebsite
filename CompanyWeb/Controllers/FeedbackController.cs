using CompanyWeb.Data.Dao.Client;
using CompanyWeb.Data.EF;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly CompanyDbContext _context;

        public FeedbackController(CompanyDbContext context)
        {
            _context = context;
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new FeedBackDao(_context);
            var daoCategoriesPost = new LayoutDao(_context);
            ViewBag.categoryPosts = daoCategoriesPost.getAllCategories();
            ViewBag.lstFeedBacks = dao.getFeedBackPaging(page, pageSize);

            return View();
        }
    }
}