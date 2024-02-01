using System.Text.RegularExpressions;

using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.ViewModels;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KursovaRabota.Controllers
{
    public class UserController : Controller
    {
        private protected UserManager<ApplicationUser> userManager;
        private protected SignInManager<ApplicationUser> signInManager;
        private protected ApplicationDbContext context;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (await signInManager.CanSignInAsync(user) && user!=null) 
            {
                var options = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true
                };

                await signInManager.SignInAsync(user, options);

                return RedirectToAction( "Index", "Home");
            }return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
