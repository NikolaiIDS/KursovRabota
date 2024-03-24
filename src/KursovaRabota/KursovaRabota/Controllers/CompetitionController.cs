using KursovaRabota.Data;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels.CompetitionVMs;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursovaRabota.Controllers
{
    public class CompetitionController : Controller
    {
        private ICompetitionService _competitionService;
        private ISubjectService _subjectService;
        private ICompetitionTypeService _competitionTypeService;

        public CompetitionController(ICompetitionService competitionService, ISubjectService subjectService, ICompetitionTypeService competitionTypeService)
        {
            _competitionService = competitionService;
            _subjectService = subjectService;
            _competitionTypeService = competitionTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _competitionService.GetAll();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(Guid id)
        {
            var users = await _competitionService.GetAllUsers(id);
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id != Guid.Empty)
            {
                var fromDb = await _competitionService.GetById(id);
                var forView = new CompetitionUpdateViewModel 
                { 
                    Id = id,
                    CompetitionTypeId = fromDb.CompetitionType.Id,
                    SubjectId = fromDb.Subject.Id,
                    Description = fromDb.Description,
                    Location = fromDb.Location,
                    MaxParticipants = fromDb.MaxParticipants,
                    Name = fromDb.Name,
                    RegistrationDeadline = fromDb.RegistrationDeadline,
                    Subjects = await _subjectService.GetAll(),
                    CompetitionTypes = await _competitionTypeService.GetAll()
                };
                return View(forView);
            }



            else
            {
                TempData["error"] = "Грешка";
                return RedirectToAction("GetAll");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompetitionUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Състезанието бе променено успешно";
                _competitionService.Update(model);
                return RedirectToAction("GetAll");
            }

            TempData["error"] = "Грешка";
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            await _competitionService.Deactivate(id);
            TempData["warning"] = "Състезанието бе деактививано успешно";
            return RedirectToAction("GetAll");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _competitionService.Deactivate(id);
            TempData["warning"] = "Състезанието бе деактививано успешно";
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CompetitionAddViewModel();

            model.Subjects = await _subjectService.GetAll();
            model.CompetitionTypes = await _competitionTypeService.GetAll();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompetitionAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _competitionService.Add(model);
                TempData["success"] = "Състезанието бе добавенд успешно";
                return RedirectToAction("GetAll");
            }
            TempData["error"] = "Възникна грешка";
            return RedirectToAction("GetAll");
        }
    }
}
