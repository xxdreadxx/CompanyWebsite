using CompanyWeb.Data.Dao.Client;
using CompanyWeb.Data.EF;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Controllers
{
    public class RecuitmentController : Controller
    {
        private readonly CompanyDbContext _context;

        public RecuitmentController(CompanyDbContext context)
        {
            _context = context;
        }

        public ActionResult Index(int id)
        {
            var dao = new RecuitmentDao(_context);
            var daoCategoriesPost = new LayoutDao(_context);
            ViewBag.rcmPatch = id;
            ViewBag.rcm = null;
            ViewBag.categoryPosts = daoCategoriesPost.getAllCategories();
            if (id == 1)
            {
                ViewBag.rcm = dao.getRecuitmentCondition();
            }
            else
            {
                ViewBag.rcm = dao.getRecuitmentProcedure();
            }

            return View();
        }

        public ActionResult RecuitmentInformation(int page = 1, int pageSize = 6)
        {
            var dao = new RecuitmentDao(_context);
            var daoCategoriesPost = new LayoutDao(_context);
            ViewBag.categoryPosts = daoCategoriesPost.getAllCategories();
            ViewBag.lstRecruitment = dao.getRecuitmentPaging(page, pageSize);

            return View();
        }

        public ActionResult DetailRecuitment(int id)
        {
            var dao = new RecuitmentDao(_context);
            var daoCategoriesPost = new LayoutDao(_context);
            ViewBag.categoryPosts = daoCategoriesPost.getAllCategories();
            ViewBag.detailRecruitment = dao.getDetailRecuitment(id);
            ViewBag.getNewRecuitment = dao.getNewRecuitments(id);

            return View();
        }
    }
}