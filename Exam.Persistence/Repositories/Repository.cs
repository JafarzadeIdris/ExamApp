using Azure.Core;
using Exam.Application.Abstractions.Repository;
using Exam.Domain.Entities.Common;
using Exam.Persistence.Contexts;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading;
using MediatR;
using Exam.Application.Common;
using Exam.Application.Dtos.Student;

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
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.FindAsync<TEntity>(id, cancellationToken);
            if (entity is null)
                throw new ArgumentNullException(nameof(id), "Entity not found");
            _context.Set<TEntity>().Remove(entity);
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

        public void Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _context.Set<TEntity>().Update(entity);
        }
        public async Task<PaginateResponse<TEntity>> GetPaginationAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var query =  _context.Set<TEntity>().AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var entity = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new PaginateResponse<TEntity>
            {
                Data = entity,
                PageNumber = pageNumber,
                TotalPages = totalPages,
                TotalCount = totalCount
            };
        }
    }
}
