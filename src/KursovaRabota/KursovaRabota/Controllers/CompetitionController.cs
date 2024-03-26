using System.Collections.Generic;

using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels.CompetitionVMs;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Controllers
{
    public class CompetitionController : Controller
    {
        private ICompetitionService _competitionService;
        private ISubjectService _subjectService;
        private ICompetitionTypeService _competitionTypeService;
        private protected SignInManager<ApplicationUser> _signInManager;

        public CompetitionController(ICompetitionService competitionService, ISubjectService subjectService, ICompetitionTypeService competitionTypeService, SignInManager<ApplicationUser> signInManager)
        {
            _competitionService = competitionService;
            _subjectService = subjectService;
            _competitionTypeService = competitionTypeService;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Teacher")]

        public async Task<IActionResult> GetAll(int? pageSize, int? pageNumber)
        {
            var list = await _competitionService.GetAll();
            var model = new CompetitionGetAllViewModel();

            model.Competitions = list;
            pageSize = pageSize ?? 1; // Default page size is 6
            pageNumber = pageNumber ?? 1; // Default page number is 1
            model.PageSize = pageSize.Value;
            model.CurrentPage = pageNumber.Value;
            model.TotalPages = (int)Math.Ceiling((double)model.Competitions.Count() / pageSize.Value);

            model.Competitions = model.Competitions
                .Skip((pageNumber.Value - 1) * pageSize.Value)
                .Take(pageSize.Value)
                .ToList();

            // Pass the paginated cars to the view
            
            return View(model);
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
        [Authorize(Roles = "Admin, Teacher")]

        public async Task<IActionResult> Add()
        {
            var model = new CompetitionAddViewModel();

            model.Subjects = await _subjectService.GetAll();
            model.CompetitionTypes = await _competitionTypeService.GetAll();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Teacher")]

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

        [HttpGet]
        [Authorize(Roles = "Student")]

        public async Task<IActionResult> GetAllSubscriptions(CompetitionAddViewModel fromView, int? pageSize = 10, int? pageNumber = 1)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            if (user != null)
            {

                var list = await _competitionService.GetAllSubscriptions(user.Id);
                var model = new CompetitionGetAllViewModel();

                model.Competitions = list;
                model.PageSize = pageSize.Value;
                model.CurrentPage = pageNumber.Value;
                model.TotalPages = (int)Math.Ceiling((double)list.Count / pageSize.Value);

                model.Competitions = list
                    .Skip((pageNumber.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value)
                    .ToList();

                return View(model);
            }

            TempData["warning"] = "Грешка";
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetAllForUser(int? pageSize = 10, int? pageNumber = 1)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            if (user != null)
            {
                var list = await _competitionService.GetAllExceptUsers(user.Id);
                var model = new CompetitionGetAllViewModel();

                model.Competitions = list;
                model.PageSize = pageSize.Value;
                model.CurrentPage = pageNumber.Value;
                model.TotalPages = (int)Math.Ceiling((double)list.Count / pageSize.Value);

                model.Competitions = list
                    .Skip((pageNumber.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value)
                    .ToList();

                return View(model);
            }

            TempData["warning"] = "Грешка";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(Guid id, int? pageSize = 10, int? pageNumber = 1)
        {
            var users = await _competitionService.GetAllUsers(id);
            

            users.PageSize = pageSize.Value;
            users.CurrentPage = pageNumber.Value;
            users.TotalPages = (int)Math.Ceiling((double)users.Students.Count / pageSize.Value);

            users.Students = users.Students
                .Skip((pageNumber.Value - 1) * pageSize.Value)
                .Take(pageSize.Value)
                .ToList();

            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> GetAllInactive(int? pageSize = 10, int? pageNumber = 1)
        {
            var list = await _competitionService.GetAllInactive();
            var model = new CompetitionGetAllViewModel();
            model.Competitions = list;

            model.PageSize = pageSize.Value;
            model.CurrentPage = pageNumber.Value;
            model.TotalPages = (int)Math.Ceiling((double)list.Count / pageSize.Value);

            model.Competitions = model.Competitions
                .Skip((pageNumber.Value - 1) * pageSize.Value)
                .Take(pageSize.Value)
                .ToList();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> GetAllFilled(int? pageSize = 10, int? pageNumber = 1)
        {
            var list = await _competitionService.GetAllInactive();
            var model = new CompetitionGetAllViewModel();
            model.Competitions = list;

            model.PageSize = pageSize.Value;
            model.CurrentPage = pageNumber.Value;
            model.TotalPages = (int)Math.Ceiling((double)list.Count / pageSize.Value);

            model.Competitions = model.Competitions
                .Skip((pageNumber.Value - 1) * pageSize.Value)
                .Take(pageSize.Value)
                .ToList();

            return View(model);
        }

    }
}
