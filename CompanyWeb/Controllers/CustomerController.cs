using CompanyWeb.Data.Dao.Client;
using CompanyWeb.Data.EF;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CompanyDbContext _context;

        public CustomerController(CompanyDbContext context)
        {
            _context = context;
        }

        public ActionResult Index(int id, int page = 1, int pageSize = 6)
        {
            var dao = new CustomerDao(_context);
            var daoCategoriesPost = new LayoutDao(_context);
            ViewBag.customerId = id;
            ViewBag.categoryPosts = daoCategoriesPost.getAllCategories();
            ViewBag.customer = dao.getAllCustomer(id, page, pageSize);

            return View();
        }
    }
}