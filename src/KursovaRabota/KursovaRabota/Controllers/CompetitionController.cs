using KursovaRabota.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace KursovaRabota.Controllers
{
    public class CompetitionController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View();
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
    }
}
