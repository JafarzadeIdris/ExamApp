using Exam.Application.Dtos.Exam;

namespace Exam.Application.Features.Exam.GetAllExam
{
    public record GetAllExamQuery() : IListQuery<ExamDto>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
