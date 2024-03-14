using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels;
using KursovaRabota.ViewModels.Enums;
using KursovaRabota.ViewModels.UserVMs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace KursovaRabota.Services
{
    public class UserService : IUserService
    {
        private protected UserManager<ApplicationUser> userManager;
        private protected SignInManager<ApplicationUser> signInManager;
        private protected ApplicationDbContext context;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        public async Task<ApplicationUser> Approve(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            user.Approved = true;
            return user;
        }

        public async Task<List<DisplayUserViewModel>> GetAllUnregistered()
        {
            var users = await context.Users
                .Where(x => x.Approved == false)
                .Select(x => new DisplayUserViewModel
                {
                    Id = Guid.Parse(x.Id),
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Approved = x.Approved,
                    DesiredRole = context.UserRoles
               .Where(ur => ur.UserId == x.Id)
               .Join(context.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name)
               .FirstOrDefault()
                })
                .ToListAsync();

            return users;
        }

        public async Task<List<DisplayUserViewModel>> GetAll()
        {
            var users = await context.Users
                .Where(x => x.Approved == true)
                .Select(x => new DisplayUserViewModel
                {
                    Id = Guid.Parse(x.Id),
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Approved = x.Approved,
                    DesiredRole = context.UserRoles
               .Where(ur => ur.UserId == x.Id)
               .Join(context.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name)
               .FirstOrDefault()
                })
                .ToListAsync();

            return users;
        }

        public async Task<LoginResult> Login(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (!user.Approved)
            {
                return LoginResult.WaitingApproval;
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (result.Succeeded)
            {
                return LoginResult.Success;
            }
            return LoginResult.Fail;
        }

        public async Task Delete(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            context.Remove(user);
        }

        public async Task Update(UpdateUserViewModel model)
        {
            if (model.SelectedSubjectIds != null)
            {
                model.TeacherSubjects = new List<Subject>();
                foreach (var item in model.SelectedSubjectIds)
                {
                    model.TeacherSubjects.Add(await context.Subjects.FindAsync(item));
                }
            }

          
                var user = await userManager.FindByEmailAsync(model.Email);
                user.UserName = model.UserName;
                user.NormalizedUserName = model.UserName.ToUpper();
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.NormalizedEmail = model.Email.ToUpper();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.TeacherSubjects = model.TeacherSubjects;

                context.Update(user);
                await context.SaveChangesAsync();
            
        }
    }
}
