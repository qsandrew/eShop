using System.Linq;
using eShop.Models;
using eShop.Models.Common;
using eShop.Models.EntInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eShop.Controllers
{
    public class LoginController : Controller
    {
        private IasContext _db;
        private readonly ILogger<HomeController> _logger;

        public LoginController(IasContext context, ILogger<HomeController> logger)
        {
            _db = context;
            _logger = logger;
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
    }
}