using eShop.BL;
using eShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class EnterpriseController : Controller
    {
        private IasContext _db;
         public EnterpriseController(IasContext context)
        {
            _db = context;
        }
        public IActionResult Employee()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPositions()
        {
            var lstPositions = EmployeeBL.GetPositions(_db);
            return Json(lstPositions);
        }
    }
}