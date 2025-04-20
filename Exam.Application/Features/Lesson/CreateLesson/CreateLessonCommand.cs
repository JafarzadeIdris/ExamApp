using Exam.Application.Abstractions.Commands;
using MediatR;


namespace Exam.Application.Features.Lesson.CreateLesson
{
    public record CreateLessonCommand(string Name,string Code,int ClassLevel,Guid TeacherId) : ICommand<Unit>
    {
    }
}
