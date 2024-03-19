using KursovaRabota.Data;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels.CompetitionVMs;
using Microsoft.AspNetCore.Mvc;

namespace KursovaRabota.Controllers
{
    public class CompetitionController : Controller
    {
        private ApplicationDbContext _context;
        private ICompetitionService _competitionService;
        private ISubjectService _subjectService;

        public CompetitionController(ApplicationDbContext context, ICompetitionService competitionService)
        {
            _context = context;
            _competitionService = competitionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list =await _competitionService.GetAll();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompetitionUpdateViewModel model)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CompetitionAddViewModel();
            return View();
        }
    }
}
