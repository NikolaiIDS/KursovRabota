using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels;
using KursovaRabota.ViewModels.Enums;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace KursovaRabota.Services
{
    public class UserService : IUserService
    {
        private protected UserManager<ApplicationUser> userManager;
        private protected SignInManager<ApplicationUser> signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<LoginResult> Login(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null || !user.Approved) 
            {
                return LoginResult.WaitingApproval;
            }

            if (await signInManager.CanSignInAsync(user) && user != null)
            {
                var options = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true
                };

                await signInManager.SignInAsync(user, options);
                return LoginResult.Success;
            }return LoginResult.Fail;
        }
    }
}
