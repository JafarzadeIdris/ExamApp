using Exam.Domain.Entities.Common;

namespace Exam.Domain.Entities
{
    public class ExamEntity : BaseEntity
    {
        public DateTime ExamDate { get; set; }
        public int Score { get; set; }

        public Guid LessonId { get; set; }
        public LessonEntity Lesson { get; set; }

        public Guid StudentId { get; set; }
        public StudentEntity Student { get; set; }
    }
}
