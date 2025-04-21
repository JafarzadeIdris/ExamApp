using Exam.Application.Dtos.Exam;


namespace Exam.Application.Features.Exam.GetExam
{
    public record GetExamQuery(Guid id) : ISingleQuery<ExamDto>
    {
    }
}
