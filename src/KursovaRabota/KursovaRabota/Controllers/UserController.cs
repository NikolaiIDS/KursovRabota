using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels;
using KursovaRabota.ViewModels.Enums;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KursovaRabota.Controllers
{
    public class UserController : Controller
    {
        private protected IUserService userService;
        private protected UserManager<ApplicationUser> userManager;
        private protected ApplicationDbContext context;
        private protected SignInManager<ApplicationUser> signInManager;

        public UserController
            (IUserService userService,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.context = context;
            this.signInManager = signInManager;
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await userService.Login(model);

            switch (result)
            {
                case LoginResult.WaitingApproval:
                    TempData["warning"] = "Your account is waiting for confirmation from the administrator.";
                    return RedirectToAction("Index", "Home");

                case LoginResult.Success:
                    TempData["success"] = "Successful login.";
                    return RedirectToAction("Index", "Home");

                case LoginResult.Fail:
                    TempData["error"] = "Unsuccessful login.";
                    return RedirectToAction("Index", "Home");

                default:
                    // Log an error or handle the unexpected case
                    return NotFound();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            //tempdata says successfully logged out
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Unsuccessful register!";
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Class = model.Class,
                PhoneNumber = model.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, model.Password);
            

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, model.DesiredRole);
                TempData["success"] = "Successful login!";
                return RedirectToAction(nameof(Login));
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }
    }
}
