

using Exam.Application.Dtos.Teacher;

namespace Exam.Application.Dtos.Lesson
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public int ClassLevel { get; private set; }
        public Guid TeacherId { get; private set; }
        

    }
}
