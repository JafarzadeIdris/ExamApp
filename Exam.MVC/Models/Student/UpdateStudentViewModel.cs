using System.ComponentModel.DataAnnotations;

namespace Exam.MVC.Models.Student
{
    public class UpdateStudentViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Number is required")]
        [Range(1, 99999, ErrorMessage = "Number must be between 1 and 99999.")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30, ErrorMessage = "Name length max 20")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Surname is required")]
        [MaxLength(30, ErrorMessage = "Surname length max 20")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "ClassLevel is required")]
        [Range(1, 11, ErrorMessage = "Class must be between 1 and 11.")]
        public int ClassLevel { get; set; }
    }
}
