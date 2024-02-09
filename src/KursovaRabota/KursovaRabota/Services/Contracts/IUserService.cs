using KursovaRabota.Data.Models;
using KursovaRabota.ViewModels;
using KursovaRabota.ViewModels.Enums;

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

    }
}
