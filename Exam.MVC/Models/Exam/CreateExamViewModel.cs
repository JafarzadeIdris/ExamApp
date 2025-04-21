using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Exam.MVC.Models.Exam
{
    public class CreateExamViewModel
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Exam date is required")]
        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Score is required")]
        [Range(0, 5, ErrorMessage = "Score must be between 0 and 5")]
        public int Score { get; set; }

        public Guid LessonId { get; set; }
        public Guid StudentId { get; set; }

        public List<SelectListItem>? Lessons { get; set; }
        public List<SelectListItem>? Students { get; set; }
    }
}
