using CompanyWeb.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdHomeController : Controller
    {
        private readonly IHttpContextAccessor contxt;
        public AdHomeController(IHttpContextAccessor httpContextAccessor)
        {
            contxt = httpContextAccessor;
        }
        public IActionResult Index()
        {
            contxt.HttpContext.Session.SetInt32("UserID", 1);
            contxt.HttpContext.Session.SetString("UserName", "HieuCT");
            return View();
        }
    }
}
