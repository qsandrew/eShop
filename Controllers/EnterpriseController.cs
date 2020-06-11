using System.Linq;
using eShop.BL;
using eShop.Models;
using eShop.Models.Common;
using eShop.Models.Enterprise;
using eShop.Models.Enterprise.Reference;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult GetEmployees(){
            var employees = _db.Employees.Include(x=>x.Position).OrderBy(x=>x.SurName);

            var lstEmployees = employees.Select(x=>new{
                x.Name, x.SurName, x.MiddleName, x.FullName,
                x.IIN, x.PositionId, PositionName = x.Position.Name,
                FromDate = x.FromDate.ToShortDateString(), x.StatusWork, StatusName = x.StatusWork.GetDescription(),
                IsEdit = false
            });
            return Json(lstEmployees);
        }

        [HttpGet]
        public IActionResult GetPositions()
        {
            var lstPositions = _db.Positions.OrderBy(p=>p.Name);
            return Json(lstPositions);
        }
        [HttpPost]
        public IActionResult SaveEmployee([FromBody]Employee emp)
        {
            if(emp.Id==0){
                _db.Employees.Add(emp);
            }
            _db.SaveChanges();
            return Json("Запись успешно сохранена");
            //bl.SaveEmployee(_db, )
        }
    }
}