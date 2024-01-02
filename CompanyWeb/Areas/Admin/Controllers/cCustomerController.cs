using CompanyWeb.Data.Dao.Admin;
using CompanyWeb.Data.EF;
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
        public cCustomerController(CompanyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Dao = new cCustomerDao(_context);
            ViewBag.lstData = Dao.getAll();
            return View();
        }
    }
}
