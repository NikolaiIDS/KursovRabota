﻿using System.Security.Cryptography.X509Certificates;

using KursovaRabota.Services.Contracts;
using KursovaRabota.ViewModels.SubjectVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursovaRabota.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
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
        public async Task<IActionResult> Add(SubjectViewModel? subjects, int? diff)
        {
            subjects.Subjects = await subjectService.GetAll();

            subjects.Subjects = subjects.Subjects
           .Where(subject =>
           (subjects.Name == null || subject.SubjectName.Contains( subjects.Name))).ToList();

            return View(subjects);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SubjectViewModel model)
        {
            if (model.SubjectName != null)
            {
                await subjectService.Add(model);
                TempData["success"] = "Предметът бе добавен успешно";
                return RedirectToAction("Add");
            }
            TempData["error"] = "Грешка в добавянето на предмета";
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            
            return View(await subjectService.GetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePOST(SubjectViewModel model)
        {
            if (model.Id != Guid.Empty)
            {
                await subjectService.Update(model);
                TempData["success"] = "Предметът бе добавен успешно";
                return RedirectToAction("Add");
            }
            TempData["error"] = "Грешка в добавянето на предмета";
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            if (id != null) 
            {
                await subjectService.Delete(Guid.Parse(id));
                TempData["success"] = "Предметът бе изтрит успешно";
                return RedirectToAction("Add");
            }
            TempData["error"] = "Грешка в изтриването на предмета";
            return RedirectToAction("Add");
        }
    }
}
