using Exam.Application.Repositories;
using Exam.Domain.Entities.Common;
using Exam.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Exam.Persistence.Repositories
{
    public class Repository<TEntity>(ExamDbContext context) : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected ExamDbContext _context = context;

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> method, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().Where(method).ToListAsync(cancellationToken);
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
