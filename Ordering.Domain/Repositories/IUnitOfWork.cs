namespace Ordering.Domain.Repositories;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync();
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
}
