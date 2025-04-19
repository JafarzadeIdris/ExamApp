using Exam.Application.Features.Exam.CreateExam;
using Exam.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam.MVC.Controllers
{
    public class HomeController(ISender sender, ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISender _sender = sender;


        public IActionResult Index(CancellationToken cancellationToken)
        {
           var res= _sender.Send(new CreateExamCommand(Guid.NewGuid()), cancellationToken);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
