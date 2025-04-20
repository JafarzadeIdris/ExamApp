using Exam.Application.Abstractions.Commands;

namespace Exam.Application.Features.Teacher.UpdateTeacher
{
    public record UpdateTeacherCommand(Guid id, string FirstName, string LastName) : ICommand<Unit>
    {
    }
}
