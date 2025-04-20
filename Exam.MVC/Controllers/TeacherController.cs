using AutoMapper;
using Exam.Application.Features.Teacher.CreateTeacher;
using Exam.Application.Features.Teacher.GetAllTeacher;
using Exam.Application.Features.Teacher.GetTeacher;
using Exam.Application.Features.Teacher.RemoveTeacher;
using Exam.Application.Features.Teacher.UpdateTeacher;
using Exam.MVC.Models.Teacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.MVC.Controllers
{
    public class TeacherController(ISender sender, IMapper mapper) : Controller
    {
        private readonly ISender _sender = sender;
        private readonly IMapper _mapper = mapper;

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var allTeacher = await _sender.Send(new GetAllTeacherQuery(),cancellationToken);
            return View(allTeacher.Value);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTeacherViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _sender.Send(_mapper.Map<CreateTeacherCommand>(model), cancellationToken);
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
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var deletedTeacher = await _sender.Send(new RemoveTeacherCommand(id),cancellationToken);
            if (deletedTeacher.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
                return BadRequest(deletedTeacher.Error);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid teacherId, CancellationToken cancellationToken)
        {
            var teacher = await _sender.Send(new GetTeacherQuery(teacherId),cancellationToken);
            UpdateTeacherViewModel teacherViewModel = _mapper.Map<UpdateTeacherViewModel>(teacher.Value);
            return View(teacherViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Teacher/Update")]
        public async Task<IActionResult> Update(UpdateTeacherViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _sender.Send(_mapper.Map<UpdateTeacherCommand>(model),cancellationToken);
                if (response.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest(response.Error);
            }
            return View(model);
        }
    }
}