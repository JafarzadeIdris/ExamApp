using Exam.Domain.Entities.Common;


namespace Exam.Domain.Entities
{
    public class TeacherEntity:BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<LessonEntity> Lessons { get; set; }
    }
}
