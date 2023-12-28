using CompanyWeb.Data.Dao.Admin;
using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class dQnAController : Controller
    {
        private readonly CompanyDbContext _context;
        public dQnAController(CompanyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Dao = new dQnADao(_context);
            ViewBag.lstData = Dao.getAll();
            return View();
        }

        [HttpGet]
        public JsonResult GetDetail(int ID)
        {
            var Dao = new dQnADao(_context);
            var detail = Dao.getDetail(ID);
            var data = new { data1 = detail, status = true };
            var result = new JsonResult(data);
            result.StatusCode = 200;
            result.ContentType = "application/json";
            return result;
        }

        [HttpPost]
        //, IFormFile file
        public JsonResult SaveData(IFormCollection f)
        {
            var Dao = new dQnADao(_context);
            bool status = true;
            string mess = "";
            dQnA item = new dQnA();
            item.ID = int.Parse(f["ID"].ToString());
            item.Question = f["Title"].ToString();
            item.Answer = f["Content"].ToString();
            item.Status = 1;
            //FileDetails fileDetails;
            //using (var reader = new StreamReader(file.OpenReadStream()))
            //{
            //    var fileContent = reader.ReadToEnd();
            //    var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            //    var fileName = parsedContentDisposition.FileName;
            //}
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
        public JsonResult ChangeStatus(int ID, byte stt)
        {
            var Dao = new dQnADao(_context);
            bool status = true;
            string mess = "";
            status = Dao.ChangeStatus(ID, stt, ref mess);
            var data = new { status = status, mess = mess };
            var result = new JsonResult(data);
            result.StatusCode = 200;
            result.ContentType = "application/json";
            return result;
        }
    }
}
