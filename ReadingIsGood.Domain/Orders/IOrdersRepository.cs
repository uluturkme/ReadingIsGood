namespace ReadingIsGood.Domain.Orders;

public interface IOrdersRepository
{
    public Task<Orders> PlaceOrder(Orders order, List<OrderItems> items);
}
