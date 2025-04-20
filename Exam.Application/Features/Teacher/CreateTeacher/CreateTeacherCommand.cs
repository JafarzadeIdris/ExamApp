using Exam.Application.Abstractions.Commands;
using MediatR;

namespace Exam.Application.Features.Teacher.CreateTeacher
{
    public record CreateTeacherCommand(string FirstName, string LastName) : ICommand<Unit>
    {
    }
}
    