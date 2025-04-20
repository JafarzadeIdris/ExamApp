using AutoMapper;
using Exam.Application.Features.Student.CreateStudent;
using Exam.Application.Features.Student.GetAllStudent;
using Exam.Application.Features.Student.GetStudent;
using Exam.Application.Features.Student.RemoveStudent;
using Exam.Application.Features.Student.UpdateStudent;
using Exam.MVC.Models.Student;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.MVC.Controllers
{
    public class StudentController(ISender sender, IMapper mapper) : Controller
    {
        private readonly ISender _sender = sender;
        private readonly IMapper _mapper = mapper;

        public async Task<IActionResult> Index()
        {
            var allStudent = await _sender.Send(new GetAllStudentQuery());
            return View(allStudent.Value);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateStudentViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _sender.Send(_mapper.Map<CreateStudentCommand>(model));
                if (response.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest(response.Error.ToString());
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Student/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedStudent = await _sender.Send(new RemoveStudentCommand(id));
            if (deletedStudent.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
                return BadRequest(deletedStudent.Error);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid studentId)
        {
            var student = await _sender.Send(new GetStudentQuery(studentId));
            UpdateStudentViewModel studentViewModel = _mapper.Map<UpdateStudentViewModel>(student.Value);
            return View(studentViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Student/Update")]
        public async Task<IActionResult> Update(UpdateStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _sender.Send(_mapper.Map<UpdateStudentCommand>(model));
                if (response.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest(response.Error);
            }
            return View(model);
        }
    }
}