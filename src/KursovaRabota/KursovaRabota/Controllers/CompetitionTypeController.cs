using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels.CompetitionTypeVMs;
using KursovaRabota.ViewModels.UserVMs;

using Microsoft.AspNetCore.Mvc;

namespace KursovaRabota.Controllers
{
    public class CompetitionTypeController : Controller
    {
        private protected ICompetitionTypeService compTypeService;

        public CompetitionTypeController(ICompetitionTypeService compTypeService)
        {
            this.compTypeService = compTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            CompetitionTypeViewModel compTypes = new();
            compTypes.AllTypes = await compTypeService.GetAll();

            return View(compTypes);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompetitionTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await compTypeService.Add(model);
                TempData["success"] = "Предметът бе добавен успешно";
                return RedirectToAction("Add");
            }
            TempData["error"] = "Грешка в добавянето на предмета";
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                await compTypeService.Delete(Guid.Parse(id));
                TempData["success"] = "Предметът бе изтрит успешно";
                return RedirectToAction("Add");
            }
            TempData["error"] = "Грешка в изтриването на предмета";
            return RedirectToAction("Add");
        }
    }
}
