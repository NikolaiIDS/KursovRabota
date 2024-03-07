using KursovaRabota.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KursovaRabota.Services.Contracts
{
    public interface ICompetitionService
    {
        Task<CompetitionGetAllViewModel> GetAll();

        Task<CompetitionGetViewModel> GetById(Guid id);

        Task<CompetitionUpdateViewModel> Update(Guid id);

        Task Delete(Guid id);

        Task<GetCompUsersViewModel> GetAllUsers(Guid id);
    }
}
