using GameStore.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IGameService _gameService;
        public ShopController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
