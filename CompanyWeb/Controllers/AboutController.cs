using CompanyWeb.Data.Dao.Client;
using CompanyWeb.Data.EF;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Controllers
{
    public class AboutController : Controller
    {
        private readonly CompanyDbContext _context;

        public AboutController(CompanyDbContext context)
        {
            _context = context;
        }

        public ActionResult Index(int id = 0)
        {
            var dao = new AboutDao(_context);
            var daoCategoriesPost = new LayoutDao(_context);
            ViewBag.categoryPosts = daoCategoriesPost.getAllCategories();
            ViewBag.AbountId = id;
            ViewBag.employee = dao.getAlldEmployee();
            ViewBag.system = dao.getData();

            return View();
        }
    }
}