

namespace Exam.Application.Abstractions.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
