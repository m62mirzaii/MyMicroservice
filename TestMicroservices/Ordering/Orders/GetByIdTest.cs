using AutoFixture;
using Moq;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrderItem;
using Ordering.Application.Features.Orders.Queries.GetById;
using Ordering.Domain.Entities.Orders;
using Ordering.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace TestMicroservices.Ordering.Orders;


public class GetByIdTest
{
    private readonly Mock<IOrderRepository> _orderRepositoryMock;
    private readonly GetByIdQueryHandler _getByIdQueryHandler;
    private readonly DeleteOrderItemCommandHandler _deleteOrderItemHandler;

    public GetByIdTest(Mock<IOrderRepository> orderRepositoryMock, GetByIdQueryHandler getByIdQueryHandler, DeleteOrderItemCommandHandler deleteOrderItemHandler)
    {
        _orderRepositoryMock = orderRepositoryMock;
        _getByIdQueryHandler = getByIdQueryHandler;
        _deleteOrderItemHandler = deleteOrderItemHandler;
    }


    [Fact]
    public async Task Handle_OrderExists_ReturnsOrderByIdDto()
    {
        // Arrange
        int orderId = 1;
        var order = new Order(1, 1, 1);
        _orderRepositoryMock.Setup(repo => repo.GetByIdAsync(orderId)).ReturnsAsync(order);


        // Act
        var query = new GetByIdQuery { Id = orderId };
        var result = await _getByIdQueryHandler.Handle(query, CancellationToken.None);


        // Assert
        Assert.NotNull(result);
        Assert.Equal(orderId, result.Id);
        Assert.Equal(1, result.OrderNumber);
        Assert.Equal("", result.CustomerName);
    }

    [Fact]
    public async Task Handle_OrderNotExist_ReturnNull()
    {
        //Arrange
        int orderId = 5;
        var order = new Order(orderId, 1, 1);
        _orderRepositoryMock.Setup(repo => repo.GetByIdAsync(orderId))
                            .ReturnsAsync((Order)null);

        //act
        var query = new GetByIdQuery { Id = orderId };
        var result = await _getByIdQueryHandler.Handle(query, CancellationToken.None);

        //Asser
        Assert.Null(result);
    }

    [Theory]
    [InlineData(1)]
    public async Task Handle_OrderNotExist_ReturnNull_Theory(int orderId)
    {
        //Arrange 
        var order = new Order(orderId, 1, 1);
        _orderRepositoryMock.Setup(repo => repo.GetByIdAsync(orderId)).ReturnsAsync((Order)null);

        //act
        var query = new GetByIdQuery { Id = orderId };
        var result = await _getByIdQueryHandler.Handle(query, CancellationToken.None);

        //Asser
        Assert.Null(result);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    public async Task Handle_DeleteExistOrder_Return_True(int orderId, int orderItemId)
    {
        //Arrange 
        var order = new Order(orderId, 1, 1);
        _orderRepositoryMock.Setup(repo => repo.DeleteOrderItemAsync(orderId, orderItemId)).ReturnsAsync(true);

        //act
        var command = new DeleteOrderItemCommand { OrderId = orderId, OrderItemId = orderItemId };
        var result = await _deleteOrderItemHandler.Handle(command, CancellationToken.None);

        //Asser
        Assert.True(result);
    }

    [Fact]
    public async Task Handle_Addd_Order_Return_OrderObject()
    {
        //Arrange
        int orderId = 5;
        var fixture = new Fixture();
        fixture.Build<Order>().Create();

        
    }
}
