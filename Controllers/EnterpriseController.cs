using System.ComponentModel.DataAnnotations;
using System.Linq;
using eShop.Models;
using eShop.Models.Common;
using eShop.Models.CowInfo;
using eShop.Models.EntInfo;
using eShop.Models.EntInfo.Reference;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eShop.Controllers
{
    [Authorize]
    public class EnterpriseController : Controller
    {
        private IasContext _db;
        private readonly ILogger<HomeController> _logger;
        public EnterpriseController(IasContext context, ILogger<HomeController> logger)
        {
            _db = context;
            _logger = logger;
        }
        public IActionResult Company()
        {
            return View();
        }



        //Фермы
        public IActionResult Farms()
        {
            return View();
        }
        public class TFarm
        {
            public string Name { get; set; }
            public FarmType Type { get; set; }
        }
       
        [HttpGet]
        public IActionResult GetFarms()
        {
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var farms = _db.Farms.Where(x => x.EnterpriseId == entId);
            if (farms.Count() > 0)
            {
                var f = farms.Select(x => new { x.Name, Type = x.FarmType.GetDescription(), IsEdit = false });
                return Json(f);
            }
            return Json("");
        }
        [HttpPost]
        public IActionResult SaveFarms([FromBody] TFarm farm)
        {
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var f = new Farm();
            f.Name = farm.Name;
            f.FarmType = farm.Type;
            f.EnterpriseId = entId;
            _db.Farms.Add(f);
            _db.SaveChanges();
            return Json("OK");
        }
        [HttpGet]
        public IActionResult GetFlocks()
        {
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var flocks = _db.Flocks.Where(x => x.EnterpriseId == entId);
            if (flocks.Count() > 0)
            {
                var f = flocks.Select(x => new { x.Name, Type = x.FarmType.GetDescription(), IsEdit = false });
                return Json(f);
            }
            return Json("");
        }
        [HttpPost]
        public IActionResult SaveFlocks([FromBody] TFarm farm)
        {
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var f = new Flock();
            f.Name = farm.Name;
            f.FarmType = farm.Type;
            f.EnterpriseId = entId;
            _db.Flocks.Add(f);
            _db.SaveChanges();
            return Json("OK");
        }

        [HttpGet]
        public IActionResult GetTabuns()
        {
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var tabuns = _db.Tabuns.Where(x => x.EnterpriseId == entId);
            if (tabuns.Count() > 0)
            {
                var f = tabuns.Select(x => new { x.Name, Type = x.FarmType.GetDescription(), IsEdit = false });
                return Json(f);
            }
            return Json("");
        }
        [HttpPost]
        public IActionResult SaveTabuns([FromBody] TFarm farm)
        {
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var f = new Tabun();
            f.Name = farm.Name;
            f.FarmType = farm.Type;
            f.EnterpriseId = entId;
            _db.Tabuns.Add(f);
            _db.SaveChanges();
            return Json("OK");
        }
        [HttpGet]
        public IActionResult GetHerds()
        {
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var herds = _db.Herds.Where(x => x.EnterpriseId == entId);
            if (herds.Count() > 0)
            {
                var f = herds.Select(x => new { x.Name, Type = x.FarmType.GetDescription(), IsEdit = false });
                return Json(f);
            }
            return Json("");
        }
        [HttpPost]
        public IActionResult SaveHerds([FromBody] TFarm farm)
        {
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var f = new Herd();
            f.Name = farm.Name;
            f.FarmType = farm.Type;
            f.EnterpriseId = entId;
            _db.Herds.Add(f);
            _db.SaveChanges();
            return Json("OK");
        }

        [HttpGet]
        public IActionResult GetCaravans()
        {
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var caravan = _db.Caravans.Where(x => x.EnterpriseId == entId);
            if (caravan.Count() > 0)
            {
                var f = caravan.Select(x => new { x.Name, Type = x.FarmType.GetDescription(), IsEdit = false });
                return Json(f);
            }
            return Json("");
        }
        [HttpPost]
        public IActionResult SaveCaravans([FromBody] TFarm farm)
        {
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var f = new Caravan();
            f.Name = farm.Name;
            f.FarmType = farm.Type;
            f.EnterpriseId = entId;
            _db.Caravans.Add(f);
            _db.SaveChanges();
            return Json("OK");
        }

        [HttpGet]
        public IActionResult GetEntInfo()
        {
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var enterprise = _db.Enterprises.Find(entId);
            var manager = _db.Employees.FirstOrDefault(x => x.EnterpriseId == entId && x.PositionId == 9);
            var data = new
            {
                EntId = enterprise.Id,
                EntName = enterprise.Name,
                EntType = enterprise.EnterpriseType.GetDescription(),
                EntXin = enterprise.XIN,
                enterprise.Address,
                enterprise.Phone,
                enterprise.Email,
                Document = enterprise.DocPath,
                EmpId = manager.Id,
                manager.SurName,
                manager.Name,
                manager.MiddleName,
                manager.IIN,
                manager.Login,
                manager.Password
            };

            return Json(data);
        }
        public class EmpInfo
        {
            public int EmpId { get; set; }
            [Required]
            public string SurName { get; set; }
            [Required]
            public string Name { get; set; }
            public string MiddleName { get; set; }
            [Required]
            [MaxLength(12), MinLength(12)]
            public string IIN { get; set; }
            [Required]
            [MinLength(5), MaxLength(8)]
            public string Login { get; set; }
            [Required]
            [MinLength(5), MaxLength(10)]
            public string Password { get; set; }
        }
        [HttpPost]
        public IActionResult SaveEntInfo([FromBody] EmpInfo empInfo)
        {
            if (ModelState.IsValid)
            {
                var emp = _db.Employees.Find(empInfo.EmpId);
                emp.SurName = empInfo.SurName;
                emp.Name = empInfo.Name;
                emp.MiddleName = empInfo.MiddleName;
                emp.IIN = empInfo.IIN;
                emp.Login = empInfo.Login;
                emp.Password = empInfo.Password;

                _db.SaveChanges();

                return Json("Успешно сохранено");
            }
            return Json("При сохранении произошла ошибка");
        }


        [Authorize(Roles = "Директор")]
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
            var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
            var employees = _db.Employees.Include(x => x.Position).Where(x => x.EnterpriseId == entId).AsQueryable();

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
                x.EnterpriseId,
                x.Id,
                x.Login,
                x.Password,
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
                IsEdit = false,
                x.RowVersion
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
                var entId = int.Parse(User.FindFirst(x => x.Type == "EnterpriseId").Value);
                emp.EnterpriseId = entId;
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
                oldEmp.Login = emp.Login;
                oldEmp.Password = emp.Password;
                //oldEmp.RowVersion  = emp.RowVersion;

                _db.Entry(oldEmp).Property("RowVersion").OriginalValue = emp.RowVersion;
            }
            try
            {

                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Json("Запись не была сохранена, так как кто-то пытался параллельно её редактировать");
            }
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