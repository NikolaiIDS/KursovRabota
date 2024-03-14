using KursovaRabota.ViewModels;
using KursovaRabota.ViewModels.CompetitionTypeVMs;

namespace KursovaRabota.Services.Contracts
{
    public interface ICompetitionTypeService
    {
        Task Add(CompetitionTypeViewModel model);
        Task Delete(Guid id);
        Task<List<CompetitionTypeViewModel>> GetAll();
    }
}
