using GameStore.DAL;
using GameStore.DAL.Models;
using GameStore.MVC.Areas.Admin.ViewModels.BasketVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GameStore.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        public CartController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToBasket(int gameId)
        {
            if (gameId <= 0) return BadRequest();
            Game? game = _context.Games.Find(gameId);
            if (game == null) return NotFound();
            var cookie = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true
            };
            BasketItemVM basketItemVM = new BasketItemVM()
            {
                Title = game.Title,
                Price = game.Price,
                Quantity = 1
            };
            var basketItem = JsonConvert.SerializeObject(basketItemVM);
            Response.Cookies.Append("BasketItem", basketItem, cookie);
            return Ok();
        }
        public IActionResult GetBasket()
        {
            var basket = Request.Cookies["BasketItem"];
            return Ok(basket);
        }
    }
}
