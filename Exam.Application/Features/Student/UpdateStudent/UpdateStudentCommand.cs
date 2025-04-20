using Exam.Application.Abstractions.Commands;
using MediatR;

namespace Exam.Application.Features.Student.UpdateStudent
{
    public record UpdateStudentCommand(Guid Id, string Name, string Surname, int Number, int ClassLevel) : ICommand<Unit>
    {
    }
}
    