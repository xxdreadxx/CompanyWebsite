using CompanyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CompanyWeb.Data.Dao.Client;
using CompanyWeb.Data.EF;

namespace CompanyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly CompanyDbContext _context;

        public HomeController(CompanyDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var dao = new HomeDao(_context);
            var daoCategoriesPost = new LayoutDao(_context);
            ViewBag.categoryPosts = daoCategoriesPost.getAllCategories();
            ViewBag.newProduct = dao.getNewdProduct();
            ViewBag.productStatic = dao.getProductStatic();
            ViewBag.customer = dao.getCustomer();
            ViewBag.feedBack = dao.getRandomFeedBack();
            ViewBag.posts = dao.getPots();

            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult SendEmail(string str)
        {
            //Email.Address = "mailnhcsatech@gmail.com";
            Email.Address = "cskh.huongvietlib@gmail.com";
            //Email.Password = "satech@123";
            Email.Password = "vjdhzxvwtsrqdccx";

            Email email = new Email();
            string noidung = str;
            email.Send("NHC.SATech@gmail.com", "Thông tin khách hàng yêu cầu tư vấn", noidung);

            var data = new { status = true, mess = "" };
            var result = new JsonResult(data);
            result.StatusCode = 200;
            result.ContentType = "application/json";
            return result;
        }
    }
}