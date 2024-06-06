using MediatR;
using Ordering.Domain.Entities.Orders;
using Ordering.Infrastructure.DataBaseContext;

namespace Ordering.Infrastructure.DispatchDomainEvents;

public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, OrderContext ctx)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Order>()
            .Where(x => x.Entity.DomainEvents.Any())
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }
}
