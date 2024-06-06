using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Features.Orders.Commands.AddOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrderItem;
using Ordering.Application.Features.Orders.Queries.GetById;
using Ordering.Domain.DomainEvents.Orders;

namespace Ordering.Application.Features;

public static class HandlerRegistr
{
    public static void HandlerRegistration(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(GetByIdQueryHandler).Assembly));
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(CreateOrderCommandHandler).Assembly));
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(DeleteOrderCommandHandler).Assembly));
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(DeleteOrderItemCommandHandler).Assembly));


        
        //services.AddScoped<IEmailService, EmailService>(); // Your email service implementation
         services.AddScoped<INotificationHandler<OrderRegisteredDomainEvent>, OrderRegisteredDomainEventHandler>();

        //services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(OrderRegisteredDomainEventHandler).Assembly));
    }
}
