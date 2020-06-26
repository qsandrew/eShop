using System.Linq;
using eShop.Models;
using eShop.Models.Common;
using eShop.Models.EntInfo;
using eShop.Models.EntInfo.Reference;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eShop.Controllers
{
    public class EnterpriseController : Controller
    {
        private IasContext _db;
<<<<<<< HEAD
        private readonly ILogger<HomeController> _logger;
        public EnterpriseController(IasContext context, ILogger<HomeController> logger)
=======
         private readonly ILogger<HomeController> _logger;
        public EnterpriseController(IasContext context,ILogger<HomeController> logger)
>>>>>>> 943e2483f353d183d8e5e4d2f29bcf34f179c849
        {
             _logger = logger;
            _db = context;
            _logger = logger;
        }
        public IActionResult Employee()
        {
            return View();
        }
        public class EmpFilter
        {
            public string Fio { get; set; }
            public string IIN { get; set; }
            public int PositionId { get; set; }
            public StatusWork Status { get; set; }
        }
        [HttpPost]
        public IActionResult GetEmployees([FromBody] EmpFilter empFilter)
        {
            var employees = _db.Employees.Include(x => x.Position).AsQueryable();

            if (!string.IsNullOrEmpty(empFilter.Fio))
            {
                employees = employees.Where(x => x.SurName.Contains(empFilter.Fio));
            }
            if (!string.IsNullOrEmpty(empFilter.IIN))
            {
                employees = employees.Where(x => x.IIN.Contains(empFilter.IIN));
            }
            if (empFilter.PositionId != 0)
            {
                employees = employees.Where(x => x.PositionId == empFilter.PositionId);
            }
            if (empFilter.Status != 0)
            {
                employees = employees.Where(x => x.StatusWork == empFilter.Status);
            }

            var lst = employees.OrderBy(x => x.SurName);

            var lstEmployees = lst.Select(x => new
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
            }).ToList();
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