using Exam.Application.Abstractions.Commands;
using MediatR;

namespace Exam.Application.Features.Student.CreateStudent
{
    public record CreateStudentCommand(Guid Id, string Name, string Surname, int Number, int ClassLevel) : ICommand<Unit>
    {
    }
}
    