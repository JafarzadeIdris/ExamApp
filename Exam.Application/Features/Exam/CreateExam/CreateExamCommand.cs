using Exam.Application.Abstractions.Commands;
using Exam.Application.Dtos.Lesson;
using Exam.Application.Dtos.Student;

namespace Exam.Application.Features.Exam.CreateExam
{
    public record CreateExamCommand(Guid Id, DateTime ExamDate, int Score, Guid LessonId, Guid StudentId) : ICommand<Unit>
    {
    }
}
