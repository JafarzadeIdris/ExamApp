
using Exam.Application.Abstractions.Repository;
using Exam.Persistence.Contexts;


namespace Exam.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExamDbContext _dbContext;

        public UnitOfWork(ExamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose() => _dbContext.Dispose();
    }
}
