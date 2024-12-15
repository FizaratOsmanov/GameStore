using GameStore.BL.Abstractions;
using GameStore.BL.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class ProductDetailController : Controller
    {

        private readonly IReviewService _reviewService;
        public ProductDetailController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }
    }
}
