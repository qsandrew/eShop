using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}