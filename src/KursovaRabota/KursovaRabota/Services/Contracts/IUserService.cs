using KursovaRabota.Data.Models;
using KursovaRabota.ViewModels;
using KursovaRabota.ViewModels.Enums;

namespace KursovaRabota.Services.Contracts
{
    public interface IUserService
    {
        Task<LoginResult> Login(LoginViewModel model);
    }
}
