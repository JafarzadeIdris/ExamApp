
using Exam.Domain.Entities.Common;
using System.Linq.Expressions;

namespace Exam.Application.Abstractions.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? method, CancellationToken cancellationToken);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> method, CancellationToken cancellationToken);
    }
}
