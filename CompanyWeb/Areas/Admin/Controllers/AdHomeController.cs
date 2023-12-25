using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
