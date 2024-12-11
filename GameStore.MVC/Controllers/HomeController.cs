using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
