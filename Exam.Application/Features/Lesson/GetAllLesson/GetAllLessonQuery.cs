using Exam.Application.Dtos.Lesson;

namespace Exam.Application.Features.Lesson.GetAllLesson
{
    public record GetAllLessonQuery : IListQuery<LessonDto>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
