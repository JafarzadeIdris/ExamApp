using Exam.Application.Abstractions.Commands;
using MediatR;

namespace Exam.Application.Features.Student.RemoveStudent
{
    public  record RemoveStudentCommand(Guid id):ICommand<Unit>
    {
    }
}
