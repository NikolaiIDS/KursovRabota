using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels.CompetitionVMs;
using KursovaRabota.ViewModels.UserVMs;

using Microsoft.EntityFrameworkCore;

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
            var model = new GetCompUsersViewModel();

            var competition = await context.Competitions
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.Id == id);

            model.Students = competition.Users;

            return model;

        }

        public async Task<CompetitionGetViewModel> GetById(Guid id)
        {
            var viewModel = await context.Competitions
                .Where(x => x.IsFull == false && x.IsActive == true)
                .Include(x => x.Users)
                .Select(x => new CompetitionGetViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Subject = x.Subject,
                    CompetitionType = x.CompetitionType,
                    IsActive = x.IsActive,
                    IsFull = x.IsFull,
                    Location = x.Location,
                    MaxParticipants = x.MaxParticipants,
                    RegistrationDeadline = x.RegistrationDeadline
                }).FirstOrDefaultAsync();

            return viewModel;
        }

        public async Task<bool> Update(CompetitionUpdateViewModel model)
        {
            var campType = await context.CompetitionTypes.FindAsync(model.CompetitionTypeId);
            var subject = await context.Subjects.FindAsync(model.SubjectId);


            var fromDb = await context.Competitions
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
                }).FirstOrDefaultAsync();
            context.Competitions.Update(fromDb);
            await context.SaveChangesAsync();
            return true;
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
                    Subject = x.Subject,
                    CompetitionType = x.CompetitionType,
                    IsActive = x.IsActive,
                    IsFull = x.IsFull,
                    Location = x.Location,
                    MaxParticipants = x.MaxParticipants,
                    RegistrationDeadline = x.RegistrationDeadline
                }).ToListAsync();

            return viewModel;
        }

        public async Task Deactivate(Guid id)
        {
            var competition = await context.Competitions.FindAsync(id);
            if (competition == null)
            {
                competition.IsActive = false;
                await context.SaveChangesAsync();
                return;
            }
            return;
        }
    }
}
