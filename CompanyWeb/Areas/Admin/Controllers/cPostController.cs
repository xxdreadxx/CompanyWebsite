using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWeb.Data.Dao.Admin;
using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;

namespace CompanyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class cPostController : Controller
    {
        private readonly CompanyDbContext _context;
        public sSystemController(CompanyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Dao = new cPostDao(_context);
            ViewBag.lstData = sDao.getAll();
            return View();
        }

        [HttpGet]
        public JsonResult GetDetail(int ID)
        {
            var Dao = new cPostDao(_context);
            var detail = Dao.getDetail(ID);
            var data = new { data = detail };
            var result = new JsonResult(data);
            result.StatusCode = 200;
            result.ContentType = "application/json";
            return result;
        }

        [HttpPost]
        public JsonResult SaveData(IFormCollection f)
        {
            var Dao = new cPostDao(_context);
            bool status = true;
            string mess = "";
            cPost item = new cPost();
            item.ID = int.Parse(f["ID"].ToString());
            item.Title = f["Title"].ToString();
            item.MetaTitle = "";
            item.Status = f["Status"].ToString();
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
            var Dao = new cPostDao(_context);
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
