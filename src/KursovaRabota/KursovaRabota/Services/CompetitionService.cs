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
            Competition comp = new Competition
            {
                CompetitionType = model.CompetitionType,
                Description = model.Description,
                IsActive = true,
                IsFull = false,
                Location = model.Location,
                MaxParticipants = model.MaxParticipants,
                Name = model.Name,
                RegistrationDeadline = model.RegistrationDeadline,
                Subject = model.Subject
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

        public async Task<CompetitionGetAllViewModel> GetAll()
        {
            CompetitionGetAllViewModel viewModel = new CompetitionGetAllViewModel();
            viewModel.Competitions = await context.Competitions.Select(x => new CompetitionGetViewModel
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

        public async Task<GetCompUsersViewModel> GetAllUsers(Guid id)
        {
            var model = new GetCompUsersViewModel();

            var competition = context.Competitions
                .Include(x => x.Users)
                .FirstOrDefault(x => x.Id == id);

            model.Students = competition.Users;

            return model;

        }

        public Task<CompetitionGetViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CompetitionUpdateViewModel> Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
