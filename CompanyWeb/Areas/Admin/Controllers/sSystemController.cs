using CompanyWeb.Data.Dao.Admin;
using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class sSystemController : Controller
    {
        private readonly CompanyDbContext _context;
        public sSystemController(CompanyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var sDao = new sSystemDao(_context);
            ViewBag.Data = sDao.getData();
            return View();
        }

        //[Validation(false)]
        [HttpPost]
        public JsonResult SaveData(IFormCollection f)
        {
            var sysDao = new sSystemDao(_context);
            sSystem item = new sSystem();
            item.Name = f["name"].ToString();
            item.Code = f["code"].ToString();
            item.History = f["lsht"].ToString();
            item.ValueAndMission = f["gtsm"].ToString();
            item.Recruitment_condition = f["utql"].ToString();
            item.Recruitment_procedure = f["utqt"].ToString();
            item.Fax = f["fax"].ToString();
            item.TaxCode = f["taxcode"].ToString();
            item.Phone = f["phone"].ToString();
            item.GoogleMap = f["map"].ToString();
            item.Email = f["email"].ToString();
            item.Zalo = f["zalo"].ToString();
            item.Facebook = f["facebook"].ToString();
            item.Instagram = f["instagram"].ToString();
            item.Tiktok = f["tiktok"].ToString();
            item.Twitter = f["twitter"].ToString();
            bool status = true;
            string mess = "";
            status = sysDao.Update(item, ref mess);
            var data = new { status = status, mess = mess };
            var result = new JsonResult(data);
            result.StatusCode = 200;
            result.ContentType = "application/json";
            return result;
        }
    }
}
