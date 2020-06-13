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
        public IActionResult GetEmployees()
        {
            var employees = _db.Employees.Include(x => x.Position).OrderBy(x => x.SurName);

            var lstEmployees = employees.Select(x => new
            {
                x.Id,
                x.Name,
                x.SurName,
                x.MiddleName,
                x.FullName,
                x.IIN,
                x.PositionId,
                PositionName = x.Position.Name,
                FromDate = x.FromDate.ToShortDateString(),
                x.StatusWork,
                StatusName = x.StatusWork.GetDescription(),
                IsEdit = false
            });
            return Json(lstEmployees);
        }

        [HttpGet]
        public IActionResult GetPositions()
        {
            var lstPositions = _db.Positions.OrderBy(p => p.Name);
            return Json(lstPositions);
        }
        [HttpPost]
        public IActionResult SaveEmployee([FromBody] Employee emp)
        {
            if (emp.Id == 0)
            {
                _db.Employees.Add(emp);
            }
            else
            {
                var oldEmp = _db.Employees.Find(emp.Id);
                oldEmp.IIN = emp.IIN;
                oldEmp.MiddleName = emp.MiddleName;
                oldEmp.Name = emp.Name;
                oldEmp.PositionId = emp.PositionId;
                oldEmp.StatusWork = emp.StatusWork;
                oldEmp.SurName = emp.SurName;
                oldEmp.FromDate = emp.FromDate;
            }
            _db.SaveChanges();
            return Json("Запись успешно сохранена");
            //bl.SaveEmployee(_db, )
        }

        [HttpPost]
        public IActionResult DeleteEmployee([FromBody] Employee emp)
        {
            var delEmp = _db.Employees.Find(emp.Id);
            _db.Employees.Remove(delEmp);
            _db.SaveChanges();
            return Json("Запись удалена");
        }
    }
}