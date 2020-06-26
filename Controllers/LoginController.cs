using eShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class LoginController : Controller
    {
        private IasContext _db;

        public LoginController(IasContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}