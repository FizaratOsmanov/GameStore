using GameStore.BL.Abstractions;
using GameStore.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.MVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IGameService _gameService;
        public ShopController(IGameService gameService, AppDbContext context)
        {
            _gameService = gameService;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var items = _context.ShopItems.ToList();
            return View(items);
        }
    }
}
