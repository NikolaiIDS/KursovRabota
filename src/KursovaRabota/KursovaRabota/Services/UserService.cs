using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels;
using KursovaRabota.ViewModels.Enums;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            if (model.SelectedSubjectIds.Count != 0)
            {
                model.TeacherSubjects = new List<Subject>();
                foreach (var item in model.SelectedSubjectIds)
                {
                    model.TeacherSubjects.Add(await context.Subjects.FindAsync(item));
                }
            }

            var userFromDb = await userManager.FindByIdAsync(model.Id.ToString());

            if (userFromDb != null)
            {
                userFromDb.UserName = model.UserName;
                userFromDb.FirstName = model.FirstName;
                userFromDb.LastName = model.LastName;
                userFromDb.PhoneNumber = model.PhoneNumber;
                userFromDb.Email = model.Email;
                userFromDb.Class = model.Class;
                userFromDb.TeacherSubjects = model.TeacherSubjects;

                // Remove user from all roles
                var userRoles = await userManager.GetRolesAsync(userFromDb);
                await userManager.RemoveFromRolesAsync(userFromDb, userRoles);

                // Add user to the desired role
                await userManager.AddToRoleAsync(userFromDb, model.DesiredRole);

                await context.SaveChangesAsync();
            }
        }
    }
}
