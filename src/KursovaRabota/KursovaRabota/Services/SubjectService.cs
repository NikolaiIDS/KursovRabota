using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels.SubjectVMs;
using Microsoft.EntityFrameworkCore;

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

        public async Task Delete(Guid id)
        {
            context.Remove(await context.Subjects.FindAsync(id));
            await context.SaveChangesAsync();   
        }

        public async Task<List<SubjectViewModel>> GetAll()
        {
            var list = await context.Subjects.Select(x => new SubjectViewModel 
            { 
                Id = x.Id,
                SubjectName = x.SubjectName
            }).ToListAsync();

            return list;
        }
    }
}
