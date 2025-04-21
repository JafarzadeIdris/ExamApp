using Exam.Application.Abstractions.Commands;
using MediatR;

namespace Exam.Application.Features.Exam.RemoveExam
{
    public record RemoveExamCommand(Guid id) : ICommand<Unit>
    {
    }
}
