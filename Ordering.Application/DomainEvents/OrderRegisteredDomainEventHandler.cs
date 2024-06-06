using MediatR; 
using Ordering.Domain.DomainEvents.Orders;

public class OrderRegisteredDomainEventHandler : INotificationHandler<OrderRegisteredDomainEvent>
{
    //private readonly IEmailService _emailService;

    //public OrderRegisteredDomainEventHandler(IEmailService emailService)
    //{
    //    _emailService = emailService;
    //}

    public async Task Handle(OrderRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        var emailMessage = $"Order with Number: {notification.OrderNumber} was registered for Customer with Id: {notification.CustomerId}.";
        var emailReciver = "m62mirzaii@gmail.com";
        var subject = "New Order Registered";
        //await _emailService.SendAsync(emailReciver, subject, emailMessage);
    }
}
