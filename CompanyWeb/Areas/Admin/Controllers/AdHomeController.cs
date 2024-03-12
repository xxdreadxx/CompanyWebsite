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
            int UserID = (int)contxt.HttpContext.Session.GetInt32("UserID");
            string UserName = contxt.HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult LogOut()
        {
            contxt.HttpContext.Session.SetInt32("UserID", 0);
            contxt.HttpContext.Session.SetString("UserName", "");
            return RedirectToAction("Index","Login");
        }
    }
}
