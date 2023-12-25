using CompanyWeb.Data.Dao.Client;
using CompanyWeb.Data.EF;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly CompanyDbContext _context;

        public ProductController(CompanyDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var dao = new ProductsDao(_context);
            ViewBag.category = dao.getCategory();
            ViewBag.products = dao.getAllProduct();

            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
