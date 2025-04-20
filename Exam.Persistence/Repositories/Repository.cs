using Exam.Application.Abstractions.Repository;
using Exam.Domain.Entities.Common;
using Exam.Persistence.Contexts;
using System.Linq.Expressions;

namespace Exam.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ExamDbContext _context;

        public Repository(ExamDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {

            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _context.Set<TEntity>().Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? method, CancellationToken cancellationToken)
        {
            if (method is null)
                return await _context.Set<TEntity>().ToListAsync(cancellationToken);
            return await _context.Set<TEntity>().Where(method).ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> method, CancellationToken cancellationToken)
        {
           return await _context.Set<TEntity>().FirstOrDefaultAsync(method, cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.FindAsync<TEntity>(id, cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
