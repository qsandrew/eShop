using eShop.Models;
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
    }
}