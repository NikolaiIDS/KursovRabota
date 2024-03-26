using System.Reflection.Metadata.Ecma335;

using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels.Enums;
using KursovaRabota.ViewModels.UserVMs;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Controllers
{
    public class UserController : Controller
    {
        private protected IUserService userService;
        private protected ICompetitionService competitionService;
        private protected UserManager<ApplicationUser> userManager;
        private protected ApplicationDbContext context;
        private protected SignInManager<ApplicationUser> signInManager;

        public UserController(IUserService userService, ICompetitionService competitionService, UserManager<ApplicationUser> userManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            this.userService = userService;
            this.competitionService = competitionService;
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
        [AllowAnonymous]
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
            var forView = new RegisterViewModel
            {
                TeacherSubjects = await context.Subjects.ToListAsync()
            };
            return View(forView);
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
                PhoneNumber = model.PhoneNumber,

            };

            if (model.DesiredRole == "Teacher")
            {
                user.TeacherSubjects = new List<Subject>();
                foreach (var item in model.SelectedSubjectIds)
                {
                    user.TeacherSubjects.Add(await context.Subjects.Where(x => x.Id == item).FirstOrDefaultAsync());
                }
            }

            var result = await userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, model.DesiredRole);
                TempData["success"] = "Successful registration!";
                return RedirectToAction(nameof(Login));
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveUser(Guid id)
        {
            await userService.Approve(id);

            await context.SaveChangesAsync();
            TempData["success"] = $"Successfuly authenticated !";
            return RedirectToAction("GetAllUnregistered");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUnregistered()
        {
            var users = await userService.GetAllUnregistered();

            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await userService.GetAll();

            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(Guid Id)
        {
            var user = await userManager.FindByIdAsync(Id.ToString());

            var roles = await userManager.GetRolesAsync(user);


            var forView = new UpdateUserViewModel
            {
                Id = Guid.Parse(user.Id),
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DesiredRole = roles[0].ToString(),
                TeacherSubjects = await context.Subjects.ToListAsync()
            };
            if (user.TeacherSubjects != null)
            {
                foreach (var subject in user.TeacherSubjects)
                {
                    forView.SelectedSubjectIds.Add(subject.Id);
                }
            }

            return View(forView);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(Guid Id, UpdateUserViewModel model)
        {
            if (Id != null)
            {
                model.Id = Id;
                if (ModelState.IsValid)
                {

                    await userService.Update(model);
                    TempData["success"] = $"Успешно променихте данните на {model.FirstName} {model.LastName}";
                    return RedirectToAction("GetAll");
                }
                else
                {
                    TempData["error"] = $"Възникна грешка!";
                    return RedirectToAction("GetAll");
                }
            }
            else
            {
                TempData["error"] = $"Възникна грешка!";
                return RedirectToAction("GetAll");
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                await userService.Delete(Id);
                await context.SaveChangesAsync();
                TempData["success"] = $"Изтрихте потребител успешно!";
                return RedirectToAction("GetAll");
            }
            TempData["error"] = $"Възникна грешка!";
            return RedirectToAction("GetAll");
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Subscribe(Guid id)
        {
            var competition = await competitionService.GetById(id);
            if(competition.CurrentParticipants != competition.MaxParticipants)
            {
                var user = await signInManager.UserManager.GetUserAsync(User);
                if (user != null && competition != null)
                {
                    await userService.Subscribe(competition, user);
                    return RedirectToAction("GetAllForUser", "Competition");

                }
                TempData["error"] = $"Възникна грешка!";
                return RedirectToAction("GetAllForUser", "Competition");
            }
            TempData["error"] = $"Възникна грешка!";
            return RedirectToAction("GetAllForUser", "Competition");
        }

    }
}
