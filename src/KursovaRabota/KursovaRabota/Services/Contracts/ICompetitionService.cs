using KursovaRabota.ViewModels.CompetitionVMs;
using KursovaRabota.ViewModels.UserVMs;
using Microsoft.AspNetCore.Mvc;

namespace KursovaRabota.Services.Contracts
{
    public interface ICompetitionService
    {
        Task Add(CompetitionAddViewModel model);

        Task<List<CompetitionGetViewModel>> GetAll();

        Task<CompetitionGetViewModel> GetById(Guid id);

        Task Update(CompetitionUpdateViewModel model);

        Task Deactivate(Guid id);
        Task Delete(Guid id);

        Task<GetCompUsersViewModel> GetAllUsers(Guid id);

        Task<List<CompetitionGetViewModel>> GetAllExceptUsers(string userId);

        Task<List<CompetitionGetViewModel>> GetAllSubscriptions(string userId);

    }
}
