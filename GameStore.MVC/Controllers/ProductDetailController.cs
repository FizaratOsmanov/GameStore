using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
