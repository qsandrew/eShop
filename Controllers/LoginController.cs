using System;
using System.IO;
using System.Linq;
using eShop.Models;
using eShop.Models.Common;
using eShop.Models.EntInfo;
using eShop.Models.EntInfo.Reference;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eShop.Controllers
{
    public class LoginController : Controller
    {
        private IasContext _db;
        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment _appEnvironment;

        public LoginController(IasContext context, ILogger<HomeController> logger, IWebHostEnvironment appEnvironment)
        {
            _db = context;
            _logger = logger;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEntTypes()
        {
            var lstEnum = EnumDesc.GetDictEnum<EnterpriseType>();
            return Json(lstEnum);
        }

        [HttpPost]
        public IActionResult SaveEnterprise(EntInfo entInfo)
        {
            //Создаем хозяйство
            var ent = new Enterprise();
            ent.Name = entInfo.Form + " \"" + entInfo.Name + "\"";
            ent.XIN = entInfo.Xin;
            ent.EnterpriseType = entInfo.Type;
            ent.Manager = entInfo.Manager;
            ent.Address = entInfo.Address;
            ent.Phone = entInfo.Phone;
            ent.Email = entInfo.EMail;

            //Создаем директора
            var emp = new Employee();
            string[] fio = entInfo.Manager.Split(' ');
            emp.SurName = fio[0];
            emp.Name = fio[1];
            if (fio.Length == 3)
            {
                emp.MiddleName = fio[2];
            }
            emp.IIN = entInfo.ManagerIin;
            emp.PositionId=9;
            emp.FromDate = DateTime.Today;
            emp.StatusWork = StatusWork.Work;

            //_db.Employees.Add(emp);
            // _db.Enterprises.Add(ent);
            // _db.SaveChanges();

            // if (entInfo.DocFile != null)
            // {
            //     // путь к папке Files
            //     string path = "/Files/" + uploadedFile.FileName;
            //     // сохраняем файл в папку Files в каталоге wwwroot
            //     using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            //     {
            //          entInfo.DocFile.CopyTo(fileStream);
            //     }
            // }

            return Json("Ок");
        }
        public class EntInfo
        {
            public string Xin { get; set; }
            public EnterpriseType Type { get; set; }
            public string Form { get; set; }
            public string Name { get; set; }
            public string Manager { get; set; }
            public string ManagerIin { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string EMail { get; set; }
            public IFormFile DocFile { get; set; }
        }
    }
}