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
            List<CartItem> cartItems = new List<CartItem>();
            string? cookie = Request.Cookies["CartItem"];
            if (cookie != null)
            {
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(cookie);
            }
            return View(cartItems);
        }

        public async Task<IActionResult> AddToCart(int Id)
        {
            ShopItem? shopItem = await _context.ShopItems.Include(g => g.game).FirstOrDefaultAsync(p => p.GameId == Id);
            if (shopItem is null)
            {
                return NotFound("not found");
            }

            List<CartItem> cart = new List<CartItem>();
            string? cookie = Request.Cookies["Cart"];
            if (cookie != null)
            {
                cart = JsonConvert.DeserializeObject<List<CartItem>>(cookie);
            }

            CartItem cartItem = new CartItem
            {
                Id = shopItem.Id,
                Title = shopItem.Title,
                GameId = shopItem.GameId,
                Price = shopItem.Price,
                ImgPath = shopItem.Img,
                Quantity = 1
            };

            CartItem? CartItem = cart.FirstOrDefault(p => p.Id == cartItem.Id);
            if (CartItem == null)
            {
                cart.Add(cartItem);
            }
            else
            {
                CartItem.Quantity ++;
            }
            string serializedObject = JsonConvert.SerializeObject(cart);
            return RedirectToAction("Index", "Shop");
        }
        public IActionResult GetBasket()
        {
            var basket = Request.Cookies["BasketItem"];
            return Ok(basket);
        }
    }
}
