using Exam.Application.Features.Teacher.CreateTeacher;
using Exam.Application.Features.Teacher.GetAllTeacher;
using Exam.Application.Features.Teacher.GetTeacher;
using Exam.Application.Features.Teacher.RemoveTeacher;
using Exam.MVC.Models.Teacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.MVC.Controllers
{
    public class TeacherController(ISender sender) : Controller
    {
        private readonly ISender _sender = sender;
        public static string ControllerName => nameof(TeacherController);

        public async Task<IActionResult> Index()
        {
            var allTeacher = await _sender.Send(new GetAllTeacherQuery());
            return View(allTeacher.Value);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTeacherViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _sender.Send(new CreateTeacherCommand(model.Id, model.FirstName, model.LastName));
                if (response.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest(response.Error.ToString());
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Teacher/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid teacherId)
        {
            var deletedTeacher = await _sender.Send(new RemoveTeacherCommand(teacherId));
            if (deletedTeacher.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
                return BadRequest(deletedTeacher.Error.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid teacherId)
        {
            var teacher = await _sender.Send(new GetTeacherQuery(teacherId));
            return View(new CreateTeacherViewModel());
        }
    }
}
