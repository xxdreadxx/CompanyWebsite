using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWeb.Data.Dao.Admin;
using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CompanyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class dEmployeeController : Controller
    {
        private readonly CompanyDbContext _context;
        IHostingEnvironment _hostingEnvironment;
        public dEmployeeController(CompanyDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var Dao = new dEmployeeDao(_context);
            ViewBag.lstData = Dao.getAll();
            return View();
        }

        [HttpGet]
        public JsonResult GetDetail(int ID)
        {
            var Dao = new dEmployeeDao(_context);
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
            string pathImg = "Content\\dEmployee\\Images";
            string filePath = "";
            string filePathImg = "";
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, pathImg);
            if (file != null)
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
            var Dao = new dEmployeeDao(_context);
            bool status = true;
            string mess = "";
            dEmployee item = new dEmployee();
            item.ID = int.Parse(f["ID"].ToString());
            item.Name = f["Name"].ToString();
            item.Position = f["Position"].ToString();
            item.ExperienceYear = f["ExperienceYear"].ToString();
            item.Content = f["Content"].ToString();
            item.Status = byte.Parse(f["Status"].ToString());
            item.Avatar = "\\" + filePathImg;
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
            var Dao = new dEmployeeDao(_context);
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
