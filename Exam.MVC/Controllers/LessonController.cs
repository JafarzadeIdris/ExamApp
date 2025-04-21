using AutoMapper;
using CSharpFunctionalExtensions;
using Exam.Application.Features.Lesson.CreateLesson;
using Exam.Application.Features.Lesson.GetAllLesson;
using Exam.Application.Features.Lesson.Lesson;
using Exam.Application.Features.Lesson.RemoveLesson;
using Exam.Application.Features.Lesson.UpdateLesson;
using Exam.Application.Features.Student.GetAllStudent;
using Exam.Application.Features.Teacher.GetAllTeacher;
using Exam.MVC.Models.Lesson;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Exam.MVC.Controllers
{
    public class LessonController(ISender sender, IMapper mapper) : Controller
    {
        private readonly ISender _sender = sender;
        private readonly IMapper _mapper = mapper;


        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllLessonQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            }, cancellationToken);
            return View(result.Value);
        }


        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var allTeachers = await _sender.Send(new GetAllTeacherQuery(), cancellationToken);

            var teacherSelectList = allTeachers.Value.Data.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.FirstName} {t.LastName}"
            }).ToList();

            return View(new CreateLessonViewModel { Teachers=teacherSelectList});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLessonViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _sender.Send(_mapper.Map<CreateLessonCommand>(model), cancellationToken);

                if (response.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest(response.Error.ToString());
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Lesson/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var deletedLesson = await _sender.Send(new RemoveLessonCommand(id), cancellationToken);
            if (deletedLesson.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
                return BadRequest(deletedLesson.Error);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid lessonId, CancellationToken cancellationToken)
        {
            var allTeachers = await _sender.Send(new GetAllTeacherQuery(), cancellationToken);

            var teacherSelectList = allTeachers.Value.Data.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.FirstName} {t.LastName}"
            }).ToList();

            var lesson = await _sender.Send(new GetLessonQuery(lessonId), cancellationToken);

            var lessonViewModel = _mapper.Map<UpdateLessonViewModel>(lesson.Value);
            lessonViewModel.Teachers = teacherSelectList;

            return View(lessonViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Lesson/Update")]
        public async Task<IActionResult> Update(UpdateLessonViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _sender.Send(_mapper.Map<UpdateLessonCommand>(model), cancellationToken);
                if (response.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest(response.Error);
            }
            return View(model);

        }

    }
}