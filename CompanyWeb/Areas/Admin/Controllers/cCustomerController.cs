using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class cCustomerController : Controller
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
    }
}
