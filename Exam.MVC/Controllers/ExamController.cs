using AutoMapper;
using CSharpFunctionalExtensions;
using Exam.Application.Features.Exam.CreateExam;
using Exam.Application.Features.Exam.GetAllExam;
using Exam.Application.Features.Exam.GetExam;
using Exam.Application.Features.Exam.RemoveExam;
using Exam.Application.Features.Exam.UpdateExam;
using Exam.Application.Features.Lesson.GetAllLesson;
using Exam.Application.Features.Student.GetAllStudent;
using Exam.MVC.Models.Exam;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Exam.MVC.Controllers
{
    public class ExamController(ISender sender, IMapper mapper) : Controller
    {
        private readonly ISender _sender = sender;
        private readonly IMapper _mapper = mapper;

        [HttpGet]

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllExamQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            }, cancellationToken);
            return View(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var allLesson = await _sender.Send(new GetAllLessonQuery(), cancellationToken);
            var allStudent = await _sender.Send(new GetAllStudentQuery(), cancellationToken);

            var allLessonList = allLesson.Value.Data.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.Name} {t.Code}"
            }).ToList();

            var allStudentList = allStudent.Value.Data.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.Surname} {t.Name}"
            }).ToList();

            return View(new CreateExamViewModel
            {
                Lessons = allLessonList,
                Students = allStudentList
            });
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExamViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _sender.Send(_mapper.Map<CreateExamCommand>(model), cancellationToken);

                if (response.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest(response.Error.ToString());
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Exam/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var deletedExam = await _sender.Send(new RemoveExamCommand(id), cancellationToken);
            if (deletedExam.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
                return BadRequest(deletedExam.Error);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid examId, CancellationToken cancellationToken)
        {
            var exam = await _sender.Send(new GetExamQuery(examId), cancellationToken);
            var examViewModel = _mapper.Map<UpdateExamViewModel>(exam.Value);

            var allLesson = await _sender.Send(new GetAllLessonQuery(), cancellationToken);
            var allStudent = await _sender.Send(new GetAllStudentQuery(), cancellationToken);

            examViewModel.Lessons = allLesson.Value.Data.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.Name} {t.Code}"
            }).ToList();

            examViewModel.Students = allStudent.Value.Data.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = $"{t.Surname} {t.Name}"
            }).ToList();

            return View(examViewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Exam/Update")]
        public async Task<IActionResult> Update(UpdateExamViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _sender.Send(_mapper.Map<UpdateExamCommand>(model), cancellationToken);
                if (response.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest(response.Error);
            }
            return View(model);

        }

    }
}