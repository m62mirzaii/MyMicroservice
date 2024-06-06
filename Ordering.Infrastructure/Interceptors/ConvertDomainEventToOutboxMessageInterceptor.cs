using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Ordering.Domain.Base;
using Ordering.Domain.Entities; 

namespace Ordering.Infrastructure.Interceptors;

public class ConvertDomainEventToOutboxMessageInterceptor : SaveChangesInterceptor
{

    //public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
    //    DbContextEventData eventData,
    //    InterceptionResult<int> result,
    //    CancellationToken cancellationToken = default)  
    //{

    //    DbContext? dbContext = eventData.Context;
    //    if (dbContext is null)
    //    {
    //        return base.SavedChangesAsync(eventData, result, cancellationToken);
    //    }

    //    var domainEntities = dbContext.ChangeTracker
    //         .Entries<AggregateRoot>()
    //         .Where(x => x.Entity.DomainEvents.Any())
    //         .ToList();

    //    var domainEvents = domainEntities
    //        .SelectMany(x => x.Entity.DomainEvents)
    //        .ToList();

    //    domainEntities.ForEach(entity => entity.Entity.ClearDomainEvents());

    //    foreach ( var domainEvent in domainEvents )
    //    {
    //        var outbox = new OutboxMessage
    //        {
    //            Status = 0,
    //            Content = JsonConvert.SerializeObject(domainEvent)
    //        };
    //        dbContext.Set<OutboxMessage>().Add(outbox);
    //    }      

    //    return base.SavedChangesAsync(eventData, result, cancellationToken);
    //}

}
