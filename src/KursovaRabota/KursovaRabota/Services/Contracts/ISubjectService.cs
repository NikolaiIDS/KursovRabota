using KursovaRabota.ViewModels;

namespace KursovaRabota.Services.Contracts
{
    public interface ISubjectService
    {
        Task Add(SubjectViewModel model);
    }
}
