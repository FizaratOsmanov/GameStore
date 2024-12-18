using GameStore.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class ContactController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
