using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Exam.MVC.Models.Lesson
{
    public class UpdateLessonViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Lesson code is required")]
        [StringLength(3, ErrorMessage = "Lesson code must be exactly 3 characters", MinimumLength = 3)]
        public string Code { get; set; }


        [Required(ErrorMessage = "Lesson name is required")]
        [MaxLength(30, ErrorMessage = "Lesson name cannot exceed 30 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Class level is required")]
        [Range(1, 11, ErrorMessage = "Class level must be between 1 and 11")]
        public int ClassLevel { get; set; }

        [Required(ErrorMessage = "Class level is required")]
        public Guid TeacherId { get; set; }
        public List<SelectListItem>? Teachers { get; set; }

    }
}
