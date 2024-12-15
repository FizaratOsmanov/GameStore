using GameStore.BL.Abstractions;
using GameStore.BL.Concretes;
using GameStore.DAL;
using GameStore.DAL.Models;
using GameStore.MVC.Areas.Admin.ViewModels.GameVM;
using GameStore.MVC.Areas.Admin.ViewModels.ReviewVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.MVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService,AppDbContext context)
        {
            _reviewService = reviewService;
            _context=context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var reviews=_context.Reviews.ToList();
            return View(reviews);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Review review)
        {
            _reviewService.CreateReview(review);
            return RedirectToAction(nameof(Index), "Game");
        }



    }
}
