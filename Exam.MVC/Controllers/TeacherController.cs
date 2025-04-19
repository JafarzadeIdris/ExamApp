using Exam.Application.Features.Teacher;
using Exam.MVC.Models.Teacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.MVC.Controllers
{
    public class TeacherController(ISender sender) : Controller
    {
        private readonly ISender _sender = sender;

        public IActionResult Index()
        {
            return View();
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
                    return RedirectToAction("Index");
                else  
                    return BadRequest(response.Error.ToString());
            }
            return View(model);
        }
    }
}
