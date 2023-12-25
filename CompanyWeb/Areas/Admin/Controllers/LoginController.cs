using Microsoft.AspNetCore.Mvc;
using CompanyWeb.Data;
using CompanyWeb.Data.Dao;
using CompanyWeb.Data.Dao.Admin;
using CompanyWeb.Data.EF;

namespace CompanyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly CompanyDbContext _context;
        public LoginController(CompanyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DangNhap(string username, string password)
        {
            var uDao = new dUserDao(_context);
            bool status = true;
            string mess = "";
            int IDUser = 0;
            byte TrangThaiUser = uDao.Login(username, password, ref mess, ref IDUser);
            if (TrangThaiUser == 0)
            {
                status = false;
                mess = "Tài khoàn đăng nhập hoặc mật khẩu không đúng, vui lòng thử lại!";
            }
            else if (TrangThaiUser == 1)
            {
                mess = "Đăng nhập thành công!";
            }

            var data = new { status = status, mess = mess };

            var result = new JsonResult(data);
            result.StatusCode = 200;
            result.ContentType = "application/json";
            return result;
        }
    }
}
