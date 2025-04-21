using Exam.Application.Abstractions.Commands;
using MediatR;

namespace Exam.Application.Features.Exam.UpdateExam
{
    public record UpdateExamCommand(Guid Id, DateTime ExamDate, int Score, Guid LessonId, Guid StudentId) : ICommand<Unit>
    {
    }
}
