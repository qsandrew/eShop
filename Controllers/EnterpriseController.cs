using eShop.BL;
using eShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class EnterpriseController : Controller
    {
        private IasContext _db;
        public IActionResult Employee(IasContext context)
        {
            _db = context;
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