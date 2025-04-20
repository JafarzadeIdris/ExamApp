using Exam.Application.Abstractions.Commands;
using MediatR;

namespace Exam.Application.Features.Teacher.CreateTeacher
{
    public record CreateTeacherCommand(Guid Id, string FirstName, string LastName) : ICommand<Unit>
    {
    }
}
    