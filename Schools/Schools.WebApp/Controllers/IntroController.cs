using Microsoft.AspNetCore.Mvc;

namespace Schools.WebApp.Controllers
{
    public class IntroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}