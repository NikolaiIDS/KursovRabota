using System.Security.Cryptography.X509Certificates;

using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels.CompetitionVMs;
using KursovaRabota.ViewModels.SubjectVMs;
using KursovaRabota.ViewModels.UserVMs;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace KursovaRabota.Services
{
    public class CompetitionService : ICompetitionService
    {

        private protected ApplicationDbContext context;

        public CompetitionService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Add(CompetitionAddViewModel model)
        {
            var campType = await context.CompetitionTypes.FindAsync(model.CompetitionTypeId);
            var subject = await context.Subjects.FindAsync(model.SubjectId);

            Competition comp = new Competition
            {
                CompetitionType = campType,
                Description = model.Description,
                IsActive = true,
                IsFull = false,
                Location = model.Location,
                MaxParticipants = model.MaxParticipants,
                Name = model.Name,
                RegistrationDeadline = model.RegistrationDeadline,
                Subject = subject
            };

            await context.AddAsync(comp);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var comp = await context.Competitions.FindAsync(id);

            context.Competitions.Remove(comp);
            await context.SaveChangesAsync();

        }

        public async Task<GetCompUsersViewModel> GetAllUsers(Guid id)
        {
            var users = await context.Competitions
               .Where(u => u.Id == id)
               .Select(x => new GetCompUsersViewModel
               {
                   Students = x.Users
               }).FirstOrDefaultAsync();

            return users;
        }

        public async Task<CompetitionGetViewModel> GetById(Guid id)
        {
            var viewModel = await context.Competitions
                .Where(x => x.Id == id)
                .Include(x => x.Users)
                .Select(x => new CompetitionGetViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Subject = new SubjectViewModel { Id = x.Subject.Id, SubjectName = x.Subject.SubjectName },
                    CompetitionType = x.CompetitionType,
                    IsActive = x.IsActive,
                    IsFull = x.IsFull,
                    Location = x.Location,
                    MaxParticipants = x.MaxParticipants,
                    RegistrationDeadline = x.RegistrationDeadline,
                    CompetitionName = x.Name,
                    Users = x.Users,
                    CurrentParticipants = x.CurrentParticipants
                }).FirstOrDefaultAsync();

            return viewModel;
        }

        public async Task Update(CompetitionUpdateViewModel model)
        {
            var campType = context.CompetitionTypes.Find(model.CompetitionTypeId);
            var subject = context.Subjects.Find(model.SubjectId);


            var fromDb = context.Competitions
                .Select(x => new Competition
                {
                    Id = x.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Subject = subject,
                    CompetitionType = campType,
                    IsActive = x.IsActive,
                    IsFull = x.IsFull,
                    Location = model.Location,
                    MaxParticipants = model.MaxParticipants,
                    RegistrationDeadline = model.RegistrationDeadline
                }).FirstOrDefault();
            context.Competitions.Update(fromDb);
            await context.SaveChangesAsync();
        }

        public async Task<List<CompetitionGetViewModel>> GetAll()
        {
            var viewModel = new List<CompetitionGetViewModel>();
            viewModel = await context.Competitions
                .Where(x => x.IsFull == false && x.IsActive == true)
                .Include(x => x.Users)
                .Select(x => new CompetitionGetViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Subject = new SubjectViewModel { Id = x.Subject.Id, SubjectName = x.Subject.SubjectName },
                    CompetitionType = x.CompetitionType,
                    IsActive = x.IsActive,
                    IsFull = x.IsFull,
                    Location = x.Location,
                    MaxParticipants = x.MaxParticipants,
                    RegistrationDeadline = x.RegistrationDeadline,
                    CurrentParticipants = x.CurrentParticipants,
                    CompetitionName = x.Name
                }).ToListAsync();

            return viewModel;
        }

        public async Task Deactivate(Guid id)
        {
            var competition = await context.Competitions.FindAsync(id);
            if (competition != null)
            {
                competition.IsActive = false;
                await context.SaveChangesAsync();
                return;
            }
            return;
        }

        public async Task Reactivate(Guid id)
        {
            var competition = await context.Competitions.FindAsync(id);
            if (competition != null)
            {
                competition.IsActive = true;
                await context.SaveChangesAsync();
                return;
            }
            return;
        }

        public async Task<List<CompetitionGetViewModel>> GetAllExceptUsers(string currentUserId)
        {

            var competitions = await context.Competitions
                .Where(c => !c.Users.Any(u => u.Id == currentUserId))
                .Where(x => x.IsFull != true)
                .Where(x => x.IsActive == true)
                .Select(x => new CompetitionGetViewModel
                {
                    CompetitionName = x.Name,
                    CompetitionType = x.CompetitionType,
                    Description = x.Description,
                    Id = x.Id,
                    IsActive = x.IsActive,
                    IsFull = x.IsFull,
                    Location = x.Location,
                    MaxParticipants = x.MaxParticipants,
                    Name = x.Name,
                    RegistrationDeadline = x.RegistrationDeadline,
                    Users = x.Users,
                    Subject = new SubjectViewModel { Id = x.Subject.Id, SubjectName = x.Subject.SubjectName },
                    CurrentParticipants = x.CurrentParticipants,
                })
                .ToListAsync();

            return competitions;
        }

        public async Task<List<CompetitionGetViewModel>> GetAllFilled()
        {

            var competitions = await context.Competitions
                .Where(x => x.IsFull != true)
                .Where(x => x.IsActive == true)
                .Select(x => new CompetitionGetViewModel
                {
                    CompetitionName = x.Name,
                    CompetitionType = x.CompetitionType,
                    Description = x.Description,
                    Id = x.Id,
                    IsActive = x.IsActive,
                    IsFull = x.IsFull,
                    Location = x.Location,
                    MaxParticipants = x.MaxParticipants,
                    Name = x.Name,
                    RegistrationDeadline = x.RegistrationDeadline,
                    Users = x.Users,
                    Subject = new SubjectViewModel { Id = x.Subject.Id, SubjectName = x.Subject.SubjectName },
                    CurrentParticipants = x.CurrentParticipants,
                })
                .ToListAsync();

            return competitions;
        }

        public async Task<List<CompetitionGetViewModel>> GetAllInactive()
        {

            var competitions = await context.Competitions
                .Where(x => x.IsFull != true)
                .Where(x => x.IsActive != true)
                .Select(x => new CompetitionGetViewModel
                {
                    CompetitionName = x.Name,
                    CompetitionType = x.CompetitionType,
                    Description = x.Description,
                    Id = x.Id,
                    IsActive = x.IsActive,
                    IsFull = x.IsFull,
                    Location = x.Location,
                    MaxParticipants = x.MaxParticipants,
                    Name = x.Name,
                    RegistrationDeadline = x.RegistrationDeadline,
                    Users = x.Users,
                    Subject = new SubjectViewModel { Id = x.Subject.Id, SubjectName = x.Subject.SubjectName },
                    CurrentParticipants = x.CurrentParticipants,
                })
                .ToListAsync();

            return competitions;
        }

        public async Task<List<CompetitionGetViewModel>> GetAllSubscriptions(string userId)
        {
            var competitions = await context.Competitions
                .Where(c => c.Users.Any(u => u.Id == userId))
                .Where(x => x.IsFull != true)
                .Select(x => new CompetitionGetViewModel
                {
                    CompetitionName = x.Name,
                    CompetitionType = x.CompetitionType,
                    Description = x.Description,
                    Id = x.Id,
                    IsActive = x.IsActive,
                    IsFull = x.IsFull,
                    Location = x.Location,
                    MaxParticipants = x.MaxParticipants,
                    Name = x.Name,
                    RegistrationDeadline = x.RegistrationDeadline,
                    Users = x.Users,
                    Subject = new SubjectViewModel { Id = x.Subject.Id, SubjectName = x.Subject.SubjectName },
                    CurrentParticipants = x.CurrentParticipants,
                })
                .ToListAsync();

            return competitions;
        }
    }
}
