using eShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eShop.Controllers
{
    [Authorize]
    public class CowController : Controller
    {
        private IasContext _db;
        public CowController(IasContext context)
        {
            _db = context;
        }

        public IActionResult CardFile()
        {
            return View();
        }

    }
}