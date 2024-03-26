using KursovaRabota.Data.Models;
using KursovaRabota.ViewModels;
using KursovaRabota.ViewModels.CompetitionVMs;
using KursovaRabota.ViewModels.Enums;
using KursovaRabota.ViewModels.UserVMs;

namespace KursovaRabota.Services.Contracts
{
    public interface IUserService
    {
        Task<LoginResult> Login(LoginViewModel model);

        Task<ApplicationUser> Approve(Guid id);

        Task<List<DisplayUserViewModel>> GetAllUnregistered();

        Task<List<DisplayUserViewModel>> GetAll();

        Task Delete(Guid id);

        Task Update(UpdateUserViewModel model);

        Task Subscribe(CompetitionGetViewModel competition, ApplicationUser user);

    }
}
