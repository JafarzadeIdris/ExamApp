using Exam.Application.Abstractions.Commands;
using MediatR;

namespace Exam.Application.Features.Lesson.UpdateLesson
{
    public record UpdateLessonCommand( Guid id,string Name, string Code, int ClassLevel, Guid TeacherId) : ICommand<Unit>
    {
    }
}
