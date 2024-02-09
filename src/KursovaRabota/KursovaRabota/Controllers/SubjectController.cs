using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursovaRabota.Controllers
{
    [Authorize(Roles ="Admin, Teacher")]
    public class SubjectController : Controller
    {
        private protected ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                await subjectService.Add(model);
                TempData["success"] = "Предметът бе добавен успешно";
                return RedirectToAction("Index","Home");
            }
            TempData["error"] = "Грешка в добавянето на предмета";
            return RedirectToAction("Index", "Home");
        }
    }
}
