using CompanyWeb.Data.Dao.Admin;
using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CompanyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class dFeedbackController : Controller
    {

        private readonly CompanyDbContext _context;
        public dFeedbackController(CompanyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Dao = new dFeedbackDao(_context);
            var pDao = new dProductDao(_context);
            ViewBag.lstData = Dao.getAll();
            ViewBag.lstdProduct = pDao.getAll();
            return View();
        }

        [HttpGet]
        public JsonResult GetDetail(int ID)
        {
            var Dao = new dFeedbackDao(_context);
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
            var Dao = new dFeedbackDao(_context);
            bool status = true;
            string mess = "";
            dFeedback item = new dFeedback();
            item.ID = int.Parse(f["ID"].ToString());
            item.Name = f["Name"].ToString();
            item.Company = f["Company"].ToString();
            item.IDProduct = int.Parse(f["IDProduct"].ToString());
            item.Star = int.Parse(f["Star"].ToString());
            item.Content = f["Content"].ToString(); ;
            item.Status = byte.Parse(f["Status"].ToString());
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
        public JsonResult ChangeStatus(int ID, byte Status)
        {
            var Dao = new dFeedbackDao(_context);
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
