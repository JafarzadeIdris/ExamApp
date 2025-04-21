

using Exam.Application.Common;

namespace Exam.Application.Abstractions.Repository
{
    public interface IExamRepository
    {
        Task<PaginateResponse<ExamEntity>> GetAllExamWithLessonAndStudent(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
