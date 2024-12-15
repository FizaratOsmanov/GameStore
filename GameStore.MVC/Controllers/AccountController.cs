using GameStore.BL.Abstractions;
using GameStore.DAL;
using GameStore.DAL.Models;
using GameStore.MVC.Areas.Admin.ViewModels.UserVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpVM userSignUpVM)
        {
            if (!ModelState.IsValid)
            {
                return View(userSignUpVM);
            }
            AppUser user = new AppUser
            {
                FirstName = userSignUpVM.FirstName,
                LastName = userSignUpVM.LastName,
                Email = userSignUpVM.Email,
                UserName=userSignUpVM.Username,
                
            };
            var result = await _userManager.CreateAsync(user, userSignUpVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View(userSignUpVM);
            }
            return RedirectToAction(nameof(Index), "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SignIn(UserSignInVM userSignInVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser? user = await _userManager.FindByEmailAsync(userSignInVM.Email);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(userSignInVM.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Email or Password is incorrect");
                    return View();
                }
            }
            var result = await _signInManager.PasswordSignInAsync(user, userSignInVM.Password, userSignInVM.IsPersistant, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email or Password is incorrect");
                return View();
            }
            return RedirectToAction(nameof(Index), "Home");
        }

    }
}
