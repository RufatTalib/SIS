using Microsoft.AspNetCore.Mvc;

namespace SIS.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
