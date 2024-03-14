using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels.CompetitionTypeVMs;

using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Services
{
    public class CompetitionTypeService : ICompetitionTypeService
    {
        private ApplicationDbContext context;

        public CompetitionTypeService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Add(CompetitionTypeViewModel model)
        {
            var forDb = new CompetitionType
            {
                Type = model.Type
            };
            await context.AddAsync(forDb);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            context.Remove(await context.CompetitionTypes.FindAsync(id));
            await context.SaveChangesAsync();
        }

        public async Task<List<CompetitionTypeViewModel>> GetAll()
        {
            var list = await context.CompetitionTypes.Select(x => new CompetitionTypeViewModel
            {
                Id = x.Id,
                Type = x.Type
            }).ToListAsync();

            return list;
        }
    }
}
