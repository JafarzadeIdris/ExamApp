
using Exam.Application.Abstractions.Repository;
using Exam.Application.Common;
using Exam.Domain.Entities;
using Exam.Persistence.Contexts;


namespace Exam.Persistence.Repositories
{
    public class ExamRepository: IExamRepository
    {
        private readonly ExamDbContext _dbContext;

        public ExamRepository(ExamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginateResponse<ExamEntity>> GetAllExamWithLessonAndStudent(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var examQuery = _dbContext.Exams.Include(x => x.Lesson).Include(x => x.Student).AsNoTracking();

            var totalCount = await examQuery.CountAsync(cancellationToken);

            var allExam = await examQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new PaginateResponse<ExamEntity>
            {
                Data = allExam,
                PageNumber = pageNumber,
                TotalPages = totalPages,
                TotalCount = totalCount
            };
        }
    }
}
