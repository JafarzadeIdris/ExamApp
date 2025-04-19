using Exam.Application.Abstractions.Commands;

namespace Exam.Application.Features.Exam.CreateExam
{
    public record CreateExamCommand(Guid Id) : ICommand<Guid>
    {
    }
}
