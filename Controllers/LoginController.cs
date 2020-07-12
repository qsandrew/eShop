using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using eShop.Models;
using eShop.Models.Common;
using eShop.Models.EntInfo;
using eShop.Models.EntInfo.Reference;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Enter()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enter(string Login, string Password)
        {
            var empl = await _db.Employees.Include(x => x.Position).FirstOrDefaultAsync(x => x.Login == Login && x.Password == Password);
            if (empl != null)
            {
                await Authenticate(empl);

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Вы не зарегистрированы либо неверно введен логин/пароль";
            return View();
        }
        [HttpGet]
        public IActionResult Role()
        {
            return View();
        }


        private async Task Authenticate(Employee user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.IIN),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Position.Name),
                new Claim("EnterpriseId", user.EnterpriseId.ToString())
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
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
            if (ModelState.IsValid)
            {
                var empIIN = _db.Employees.SingleOrDefault(x => x.IIN == entInfo.ManagerIin);
                if (empIIN != null)
                {
                    return Json("Сотрудник с таким ИИНом уже существует");
                }
                empIIN = _db.Employees.SingleOrDefault(x => x.Login == entInfo.Login);
                if (empIIN != null)
                {
                    return Json("Сотрудник с таким Логином уже существует");
                }
                var entXin = _db.Enterprises.SingleOrDefault(x => x.XIN == entInfo.Xin);
                if (entXin != null)
                {
                    return Json("Хозяйство с таким БИН/ИИН уже существует");
                }

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
                emp.Login = entInfo.Login;
                emp.Password = entInfo.Password;
                emp.IIN = entInfo.ManagerIin;
                emp.PositionId = 9;
                emp.FromDate = DateTime.Today;
                emp.StatusWork = StatusWork.Work;
                emp.Enterprise = ent;

                _db.Enterprises.Add(ent);
                _db.Employees.Add(emp);

                _db.SaveChanges();

                if (entInfo.DocFile != null)
                {
                    // путь к папке Files
                    string path = "/Enterprise/" + ent.Id + "/RegistrationDoc" + Path.GetExtension(entInfo.DocFile.FileName);
                    // сохраняем файл в папку Files в каталоге wwwroot
                    Directory.CreateDirectory(_appEnvironment.WebRootPath + "/Enterprise/" + ent.Id + "/");
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        entInfo.DocFile.CopyTo(fileStream);
                    }
                    ent.DocPath = path;
                    _db.SaveChanges();
                }

                return Json("Вы успешно зарегистрированы. Попробуйте зайти на сайт");
            }
            string messages = string.Join("; ", ModelState.Values
                                                        .SelectMany(x => x.Errors)
                                                                .Select(x => x.ErrorMessage));
            return Json("Ошибка при сохранении: " + messages);
        }

        // }
        // catch (DbUpdateException ex)
        // {
        //     if(ex.InnerException!=null){
        //         return Json(ex.InnerException.Message);
        //     }
        //     return Json(ex.Message);
        // }
        public class EntInfo
        {
            [Required]
            [MinLength(5), MaxLength(8)]
            public string Login { get; set; }
            [Required]
            [MinLength(5), MaxLength(10)]
            public string Password { get; set; }
            [Required]
            [MaxLength(12), MinLength(12)]
            public string Xin { get; set; }
            public EnterpriseType Type { get; set; }
            public string Form { get; set; }
            public string Name { get; set; }
            public string Manager { get; set; }
            [Required]
            [MaxLength(12), MinLength(12)]
            public string ManagerIin { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string EMail { get; set; }
            public IFormFile DocFile { get; set; }
        }
    }
}