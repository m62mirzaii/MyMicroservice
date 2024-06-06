using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Ordering.Domain.Base;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.DataBaseContext;

namespace Ordering.Infrastructure.BackgroundJobs;

public class ProcessOutboxMessagesJob : BackgroundService
{
    private readonly OrderContext _orderContext;
    private readonly IPublisher _publisher;

    public ProcessOutboxMessagesJob(IPublisher publisher, OrderContext orderContext)
    {
        _publisher = publisher;
        _orderContext = orderContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var messages = await _orderContext.Set<OutboxMessage>()
            .Where(e => e.Status == 1)
            .ToListAsync();

        foreach (var message in messages)
        {
            IDomainEvent domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(message.Content);

            if (domainEvent == null) { continue; }

            await _publisher.Publish(domainEvent);

            message.CreateDate = DateTime.UtcNow;
        }

        await _orderContext.SaveChangesAsync();
    }
}
