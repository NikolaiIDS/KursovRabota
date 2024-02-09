using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels;

namespace KursovaRabota.Services
{
    public class SubjectService : ISubjectService
    {
        private protected ApplicationDbContext context;

        public SubjectService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Add(SubjectViewModel model)
        {
            var forDb = new Subject
            {
                SubjectName = model.SubjectName
            };
            await context.AddAsync(forDb);
            await context.SaveChangesAsync();
        }
    }
}
