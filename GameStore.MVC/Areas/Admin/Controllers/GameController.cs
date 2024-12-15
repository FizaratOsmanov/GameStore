using GameStore.BL.Abstractions;
using GameStore.DAL;
using GameStore.DAL.Models;
using GameStore.MVC.Areas.Admin.ViewModels.GameVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
namespace GameStore.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GameController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IGameService _gameService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GameController(IGameService gameService,IWebHostEnvironment webHostEnvironment, AppDbContext appDbContext)
        {
            _gameService = gameService;
            _webHostEnvironment = webHostEnvironment;
            _appDbContext=appDbContext;
        }



        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Game> games = _gameService.GetAllGames();
            return View(games);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(GameCreateVM gameCreateVM)
        {
            if (gameCreateVM.ImgUrl is null)
            {
                return View(gameCreateVM);
            }
            string fileName = Path.GetFileNameWithoutExtension(gameCreateVM.ImgUrl.FileName);
            if (gameCreateVM.ImgUrl.Length > 5 * 1024 * 1024)
            {
                ModelState.AddModelError("Img", "Fayl cox boyukdur.");
                return View(gameCreateVM);
            }
            string[] allowedFormat = [".jpg", ".png", ".jpeg", ".svg", ".webp"];
            string extension = Path.GetExtension(gameCreateVM.ImgUrl.FileName);
            bool isAllowed = false;
            foreach (var format in allowedFormat)
            {
                if (format == extension)
                {
                    isAllowed = true;
                    break;
                }
            }
            if (!isAllowed)
            {
                ModelState.AddModelError("Img", "Fayl desteklenmir");
                return View(gameCreateVM);
            }

            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "GameFolder");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            if (Path.Exists(Path.Combine(uploadPath, fileName + extension)))
            {
                fileName = fileName + Guid.NewGuid().ToString();
            }
            fileName = fileName + extension;
            uploadPath = Path.Combine(uploadPath, fileName);
            using FileStream fileStream = new FileStream(uploadPath, FileMode.Create);
            gameCreateVM.ImgUrl.CopyToAsync(fileStream);
            
            Game game = new Game()
            {
                Title = gameCreateVM.Title,
                Description = gameCreateVM.Description,
                Price = gameCreateVM.Price,
                GameID = gameCreateVM.GameID,
                Img = fileName
            };
            _gameService.CreateGame(game);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index),"Game");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            Game game = _gameService.GetGameById(id);
            return View(game);
        }


        [HttpPost]
        public IActionResult Update(int id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return View(game);
            }
            _gameService.UpdateGame(id, game);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult SoftDelete(int id)
        {
            _gameService.SoftDeleteGame(id);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult HardDelete(int id)
        {
            _gameService.HardDeleteGame(id);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
