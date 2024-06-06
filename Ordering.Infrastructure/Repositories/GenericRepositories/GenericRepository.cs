using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Base;
using Ordering.Infrastructure.DataBaseContext;

namespace Ordering.Infrastructure.Repositories.GenericRepositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
{
    private readonly OrderContext _dbContext;

    public GenericRepository(OrderContext orderContext)
    {
        _dbContext = orderContext;
    }

    public IQueryable<TEntity> GetAsQueryable()
    {
        return _dbContext.Set<TEntity>().AsQueryable();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbContext.FindAsync<TEntity>(id);
    }

    public void Add(TEntity entity)
    {
        _dbContext.Add(entity);
    }

    public void AddRange(TEntity[] entities)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        var removed = false;
        var entity = _dbContext.Find<TEntity>(id);
        if (entity != null)
        {
            removed = true;
            _dbContext.Remove(entity);
        }
        return removed;
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(TEntity[] entities)
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity entity)
    {
        if (entity != null)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }

    
}
