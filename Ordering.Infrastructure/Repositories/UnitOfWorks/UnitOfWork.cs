using MediatR; 
using Ordering.Domain.Repositories;
using Ordering.Infrastructure.DataBaseContext;
using Ordering.Infrastructure.DispatchDomainEvents;

namespace Ordering.Infrastructure.Repositories.UnitOfWorks;

public class UnitOfWork(OrderContext context, IMediator mediator) : IUnitOfWork
{
    public async Task<bool> SaveChangesAsync()
    {
        await mediator.DispatchDomainEventsAsync(context);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
    {
        await mediator.DispatchDomainEventsAsync(context);
        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}
