using KursovaRabota.ViewModels.SubjectVMs;

namespace KursovaRabota.Services.Contracts
{
    public interface ISubjectService
    {
        Task Add(SubjectViewModel model);
        Task Delete(Guid id);
        Task Update(SubjectViewModel model);
        Task<List<SubjectViewModel>> GetAll();
        Task<SubjectViewModel> GetById(Guid id);
    }
}
