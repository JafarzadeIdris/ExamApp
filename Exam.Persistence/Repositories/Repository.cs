using Exam.Application.Abstractions.Repository;
using Exam.Domain.Entities.Common;
using Exam.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace Exam.Persistence.Repositories
{
    public class Repository<TEntity>(ExamDbContext context, IServiceScopeFactory scopeFactory) : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ExamDbContext _context = context;
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService< ExamDbContext > ();
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<ExamDbContext>();
            _context.Remove(id);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> method, CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<ExamDbContext>();
            return await _context.Set<TEntity>().Where(method).ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<ExamDbContext>();
            return await _context.FindAsync<TEntity>(id, cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<ExamDbContext>();
            entity.UpdatedDate = DateTime.UtcNow;
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
