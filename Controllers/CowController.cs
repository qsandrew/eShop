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
        private readonly ILogger<CowController> _logger;
        public CowController(IasContext context, ILogger<CowController> logger)
        {
            _db = context;
            _logger = logger;
        }

        public IActionResult CardFile()
        {
            return View();
        }

    }
}