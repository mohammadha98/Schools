using Microsoft.AspNetCore.Mvc;

namespace Schools.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}