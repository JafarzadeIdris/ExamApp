using Exam.Application.Dtos.Lesson;
using Exam.Application.Dtos.Student;


namespace Exam.Application.Dtos.Exam
{
    public class ExamDto
    {
        public Guid Id { get;  set; }

        public DateTime ExamDate { get;  set; }
        public int Score { get;  set; }

        public Guid LessonId { get;  set; }
        public LessonDto Lesson { get;  set; }

        public Guid StudentId { get;  set; }
        public StudentDto Student { get;  set; }
    }
}
