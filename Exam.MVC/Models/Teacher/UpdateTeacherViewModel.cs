using System.ComponentModel.DataAnnotations;

namespace Exam.MVC.Models.Teacher
{
    public class UpdateTeacherViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(20, ErrorMessage = "FirstName length max 20")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(20, ErrorMessage = "LastName length max 20")]
        public string LastName { get; set; }
    }
}
