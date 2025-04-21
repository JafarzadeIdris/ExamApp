using Exam.Application.Abstractions.Commands;
using MediatR;

namespace Exam.Application.Features.Lesson.RemoveLesson
{
    public record RemoveLessonCommand(Guid id) : ICommand<Unit>
    {
    }
}
