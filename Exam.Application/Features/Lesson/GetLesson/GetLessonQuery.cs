using Exam.Application.Dtos.Lesson;


namespace Exam.Application.Features.Lesson.Lesson
{
    public record GetLessonQuery(Guid id) : ISingleQuery<LessonDto>
    {
    }
}
