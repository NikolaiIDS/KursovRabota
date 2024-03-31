using System.Security.Claims;

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


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KursovaRabota.ViewModels.CompetitionVMs;

namespace KursovaRabota.Services
{
    public class UserService : IUserService
    {
        private protected UserManager<ApplicationUser> userManager;
        private protected SignInManager<ApplicationUser> signInManager;
        private protected ICompetitionService competitionService;
        private protected ApplicationDbContext context;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICompetitionService competitionService, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.competitionService = competitionService;
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
                    Class = x.Class,
                    PhoneNumber = x.PhoneNumber,
                    Approved = x.Approved,
                    TeacherSubjects = x.TeacherSubjects.Select(y => new ViewModels.SubjectVMs.SubjectViewModel { Id = y.Id, SubjectName = y.SubjectName }).ToList(),
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
                    Class = x.Class,
                    TeacherSubjects = x.TeacherSubjects.Select(y => new ViewModels.SubjectVMs.SubjectViewModel { Id = y.Id, SubjectName = y.SubjectName }).ToList(),
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

            var user = await context.Users
          .Include(u => u.TeacherSubjects)
          .FirstOrDefaultAsync(u => u.Id == model.Id.ToString());


            // Update user properties
            user.UserName = model.UserName;
            user.NormalizedUserName = model.UserName.ToUpper();
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.NormalizedEmail = model.Email.ToUpper();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Class = model.Class;

            user.TeacherSubjects.Clear();

            // Add existing TeacherSubjects
            foreach (var subject in model.TeacherSubjects)
            {
                user.TeacherSubjects.Add(subject);
            }

            await context.SaveChangesAsync();
        }

        public async Task Subscribe(CompetitionGetViewModel competition, ApplicationUser user)
        {
            user.Competitions = new List<Competition>();
            if (competition.Id != Guid.Empty)
            {
                var competitionForDb = await context.Competitions.Select(x => new Competition
                {
                    Id = competition.Id,
                    Name = competition.Name,
                    CompetitionType = competition.CompetitionType,
                    Description = competition.Description,
                    IsActive = competition.IsActive,
                    IsFull = competition.IsFull,
                    Location = competition.Location,
                    MaxParticipants = competition.MaxParticipants,
                    RegistrationDeadline = competition.RegistrationDeadline,
                    Users = competition.Users,
                    Subject = new Subject { Id = competition.Subject.Id, SubjectName = competition.Subject.SubjectName},
                    CurrentParticipants = competition.CurrentParticipants
                }).FirstOrDefaultAsync();

                if (competitionForDb.MaxParticipants == competitionForDb.CurrentParticipants)
                {
                    competitionForDb.IsFull = true;
                }

                user.Competitions.Add(competitionForDb);
                competitionForDb.CurrentParticipants++;
                context.Update(user);
                context.Update(competitionForDb);
                await context.SaveChangesAsync();
            }
        }
    }
}
