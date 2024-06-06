using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Base;
using Ordering.Infrastructure.DataBaseContext;

namespace Ordering.Infrastructure.Repositories.GenericRepositories;

public class GenericRepository2<TEntity>(OrderContext dbContext) where TEntity : class, IEntity
{
    public IQueryable<TEntity> GetAsQueryable()
    {
        return dbContext.Set<TEntity>().AsQueryable();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await dbContext.FindAsync<TEntity>(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await dbContext.AddAsync(entity);
    }

    public void AddRange(TEntity[] entities)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
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
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
