using KursovaRabota.ViewModels;
using KursovaRabota.ViewModels.CompetitionTypeVMs;
using KursovaRabota.ViewModels.SubjectVMs;

namespace KursovaRabota.Services.Contracts
{
    public interface ICompetitionTypeService
    {
        Task Add(CompetitionTypeViewModel model);
        Task Delete(Guid id);
        Task<List<CompetitionTypeViewModel>> GetAll();
        Task Update(CompetitionTypeViewModel model);
        Task<CompetitionTypeViewModel> GetById(Guid id);
    }
}
