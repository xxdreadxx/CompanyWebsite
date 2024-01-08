using CompanyWeb.Data.Dao.Admin;
using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CompanyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class dCustomerController : Controller
    {
        private readonly CompanyDbContext _context;
        IHostingEnvironment _hostingEnvironment;
        public dCustomerController(CompanyDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var Dao = new dCustomerDao(_context);
            var CDao = new cCustomerDao(_context);
            ViewBag.lstData = Dao.getAll();
            ViewBag.lstCCus = CDao.getAll();
            return View();
        }

        [HttpGet]
        public JsonResult GetDetail(int ID)
        {
            var Dao = new dCustomerDao(_context);
            var detail = Dao.getDetail(ID);
            var data = new { data1 = detail, status = true };
            var result = new JsonResult(data);
            result.StatusCode = 200;
            result.ContentType = "application/json";
            return result;
        }

        [HttpPost]
        //, IFormFile file
        public async Task<JsonResult> SaveData(IFormCollection f, IFormFile file)
        {
            string pathImg = "Content\\dCustomer\\Images";
            string filePath = "";
            string filePathImg = "";
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, pathImg);
            if (file.Length > 0)
            {
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                filePath = Path.Combine(uploads, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    filePathImg = Path.Combine(pathImg, file.FileName);
                }
            }
            var Dao = new dCustomerDao(_context);
            bool status = true;
            string mess = "";
            dCustomer item = new dCustomer();
            item.ID = int.Parse(f["ID"].ToString());
            item.Title = f["Title"].ToString();
            item.Content = f["Content"].ToString();
            item.ID_CCustomer = int.Parse(f["ID_CCustomer"].ToString());
            item.MetaTitle = "";
            item.Avatar = "\\" + filePathImg;
            item.Status = byte.Parse(f["Status"].ToString());
            if (item.ID == 0)
            {
                status = Dao.Add(item, ref mess);
            }
            else
            {
                status = Dao.Update(item, ref mess);
            }
            var data = new { status = status, mess = mess };
            var result = new JsonResult(data);
            result.StatusCode = 200;
            result.ContentType = "application/json";
            return result;
        }

        [HttpPost]
        public JsonResult ChangeStatus(int ID, byte Status)
        {
            var Dao = new dCustomerDao(_context);
            bool status = true;
            string mess = "";
            status = Dao.ChangeStatus(ID, Status, ref mess);
            var data = new { status = status, mess = mess };
            var result = new JsonResult(data);
            result.StatusCode = 200;
            result.ContentType = "application/json";
            return result;
        }
    }
}
