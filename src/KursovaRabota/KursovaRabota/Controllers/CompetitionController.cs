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
        [Authorize(Roles = "Admin, Teacher, Student")]

        public async Task<IActionResult> GetAll(CompetitionGetAllViewModel? model, int? pageSize, int? pageNumber)
        {
            var list = await _competitionService.GetAll();

            model.Subjects = await _subjectService.GetAll();

            if (model.Subject != null)
            {
                model.Subject = await _subjectService.GetById(model.Subject.Id);
            }

            model.Competitions = list;
            pageSize = pageSize ?? 5;
            pageNumber = pageNumber ?? 1;
            model.PageSize = pageSize.Value;
            model.CurrentPage = pageNumber.Value;
            model.TotalPages = (int)Math.Ceiling((double)model.Competitions.Count() / pageSize.Value);

            if (model.SortByDate == true)
            {
                model.Competitions=model.Competitions.OrderBy(x => x.DateOfConduct).ToList();
            }
            else
            {
                model.Competitions = model.Competitions.OrderByDescending(x => x.DateOfConduct).ToList();
            }

            model.Competitions = model.Competitions
            .Where(competition =>
                (model.PlaceOfConduct == null || competition.Location.Contains(model.PlaceOfConduct)) &&
                (model.DateOfConduct == DateTime.MinValue || model.DateOfConduct == competition.DateOfConduct) &&
                (model.Subject == null || model.Subject.Id == competition.Subject.Id))
            .ToList();

            model.Competitions = model.Competitions
                    .Skip((pageNumber.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value)
                    .ToList();

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
        [HttpGet]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            await _competitionService.Deactivate(id);
            TempData["warning"] = "Състезанието бе деактививано успешно";
            return RedirectToAction("GetAll");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Reactivate(Guid id)
        {
            await _competitionService.Reactivate(id);
            TempData["success"] = "Състезанието бе деактививано възстановено";
            return RedirectToAction("GetAll");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _competitionService.Delete(id);
            TempData["warning"] = "Състезанието бе изтрито успешно";
            return RedirectToAction("GetAllInactive");
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

        public async Task<IActionResult> GetAllSubscriptions(CompetitionGetAllViewModel? model, int? pageSize = 10, int? pageNumber = 1)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            if (user != null)
            {

                var list = await _competitionService.GetAllSubscriptions(user.Id);

                model.Subjects = await _subjectService.GetAll();

                if (model.Subject != null)
                {
                    model.Subject = await _subjectService.GetById(model.Subject.Id);
                }

                model.Competitions = list;
                pageSize = pageSize ?? 5;
                pageNumber = pageNumber ?? 1;
                model.PageSize = pageSize.Value;
                model.CurrentPage = pageNumber.Value;
                model.TotalPages = (int)Math.Ceiling((double)model.Competitions.Count() / pageSize.Value);

                if (model.SortByDate == true)
                {
                    model.Competitions = model.Competitions.OrderBy(x => x.DateOfConduct).ToList();
                }
                else
                {
                    model.Competitions = model.Competitions.OrderByDescending(x => x.DateOfConduct).ToList();
                }

                model.Competitions = model.Competitions
                .Where(competition =>
                    (model.PlaceOfConduct == null || competition.Location.Contains(model.PlaceOfConduct)) &&
                    (model.DateOfConduct == DateTime.MinValue || model.DateOfConduct == competition.DateOfConduct) &&
                    (model.Subject == null || model.Subject.Id == competition.Subject.Id))
                .ToList();

                model.Competitions = model.Competitions
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
        public async Task<IActionResult> GetAllForUser(CompetitionGetAllViewModel? model, int? pageSize = 10, int? pageNumber = 1)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            if (user != null)
            {
                var list = await _competitionService.GetAllExceptUsers(user.Id);

                model.Subjects = await _subjectService.GetAll();

                if (model.Subject != null)
                {
                    model.Subject = await _subjectService.GetById(model.Subject.Id);
                }

                model.Competitions = list;
                pageSize = pageSize ?? 5;
                pageNumber = pageNumber ?? 1;
                model.PageSize = pageSize.Value;
                model.CurrentPage = pageNumber.Value;
                model.TotalPages = (int)Math.Ceiling((double)model.Competitions.Count() / pageSize.Value);

                if (model.SortByDate == true)
                {
                    model.Competitions = model.Competitions.OrderBy(x => x.DateOfConduct).ToList();
                }
                else
                {
                    model.Competitions = model.Competitions.OrderByDescending(x => x.DateOfConduct).ToList();
                }

                model.Competitions = model.Competitions
                .Where(competition =>
                    (model.PlaceOfConduct == null || competition.Location.Contains(model.PlaceOfConduct)) &&
                    (model.DateOfConduct == DateTime.MinValue || model.DateOfConduct == competition.DateOfConduct) &&
                    (model.Subject == null || model.Subject.Id == competition.Subject.Id))
                .ToList();

                model.Competitions = model.Competitions
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
        public async Task<IActionResult> GetAllInactive(CompetitionGetAllViewModel? model, int? pageSize = 10, int? pageNumber = 1)
        {
            var list = await _competitionService.GetAllInactive();

            model.Subjects = await _subjectService.GetAll();

            if (model.Subject != null)
            {
                model.Subject = await _subjectService.GetById(model.Subject.Id);
            }

            model.Competitions = list;
            pageSize = pageSize ?? 5;
            pageNumber = pageNumber ?? 1;
            model.PageSize = pageSize.Value;
            model.CurrentPage = pageNumber.Value;
            model.TotalPages = (int)Math.Ceiling((double)model.Competitions.Count() / pageSize.Value);

            if (model.SortByDate == true)
            {
                model.Competitions = model.Competitions.OrderBy(x => x.DateOfConduct).ToList();
            }
            else
            {
                model.Competitions = model.Competitions.OrderByDescending(x => x.DateOfConduct).ToList();
            }

            model.Competitions = model.Competitions
            .Where(competition =>
                (model.PlaceOfConduct == null || competition.Location.Contains(model.PlaceOfConduct)) &&
                (model.DateOfConduct == DateTime.MinValue || model.DateOfConduct == competition.DateOfConduct) &&
                (model.Subject == null || model.Subject.Id == competition.Subject.Id))
            .ToList();

            model.Competitions = model.Competitions
                    .Skip((pageNumber.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value)
                    .ToList();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> GetAllFilled(CompetitionGetAllViewModel? model, int? pageSize = 10, int? pageNumber = 1)
        {
            var list = await _competitionService.GetAllFilled();

            model.Subjects = await _subjectService.GetAll();

            if (model.Subject != null)
            {
                model.Subject = await _subjectService.GetById(model.Subject.Id);
            }

            model.Competitions = list;
            pageSize = pageSize ?? 5;
            pageNumber = pageNumber ?? 1;
            model.PageSize = pageSize.Value;
            model.CurrentPage = pageNumber.Value;
            model.TotalPages = (int)Math.Ceiling((double)model.Competitions.Count() / pageSize.Value);

            if (model.SortByDate == true)
            {
                model.Competitions = model.Competitions.OrderBy(x => x.DateOfConduct).ToList();
            }
            else
            {
                model.Competitions = model.Competitions.OrderByDescending(x => x.DateOfConduct).ToList();
            }

            model.Competitions = model.Competitions
            .Where(competition =>
                (model.PlaceOfConduct == null || competition.Location.Contains(model.PlaceOfConduct)) &&
                (model.DateOfConduct == DateTime.MinValue || model.DateOfConduct == competition.DateOfConduct) &&
                (model.Subject == null || model.Subject.Id == competition.Subject.Id))
            .ToList();

            model.Competitions = model.Competitions
                    .Skip((pageNumber.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value)
                    .ToList();

            return View(model);
        }

    }
}
