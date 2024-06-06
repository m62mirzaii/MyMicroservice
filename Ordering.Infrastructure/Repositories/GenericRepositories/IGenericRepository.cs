using Ordering.Domain.Base;

namespace Ordering.Infrastructure.Repositories.GenericRepositories;

public interface IGenericRepository<TEntity> where TEntity : class, IEntity
{
    IQueryable<TEntity> GetAsQueryable();

    Task<TEntity> GetByIdAsync(int id);

    void Add(TEntity entity);

    void Update(TEntity entity);

    bool Delete(int id);

    void Delete(TEntity entity);
}
