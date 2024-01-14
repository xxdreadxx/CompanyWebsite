using CompanyWeb.Data.Dao.Admin;
using CompanyWeb.Data.EF;
using CompanyWeb.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CompanyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class sSystemController : Controller
    {
        private readonly CompanyDbContext _context;
        IHostingEnvironment _hostingEnvironment;
        public sSystemController(CompanyDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var sDao = new sSystemDao(_context);
            ViewBag.Data = sDao.getData();
            return View();
        }

        //[Validation(false)]
        //IList<IFormFile> files
        [HttpPost]
        public async Task<JsonResult> SaveData(IFormCollection f, IFormFile file)
        {
            try
            {
                string pathImg = "Content\\sSystem\\Images";
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
                        filePathImg= Path.Combine(pathImg, file.FileName);
                    }
                }
                var sysDao = new sSystemDao(_context);
                sSystem item = new sSystem();
                item.Name = f["name"].ToString();
                item.Code = f["code"].ToString();
                item.History = f["lsht"].ToString();
                item.Address = f["address"].ToString();
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
                item.Favicon = "\\" + filePathImg;
                bool status = true;
                string mess = "";
                status = sysDao.Update(item, ref mess);
                var data = new { status = status, mess = mess };
                var result = new JsonResult(data);
                result.StatusCode = 200;
                result.ContentType = "application/json";
                return result;
            }
            catch (Exception ex) {
                var data = new { status = false, mess = ex };
                var result = new JsonResult(data);
                result.StatusCode = 200;
                result.ContentType = "application/json";
                return result;
            }
        }
    }
}
