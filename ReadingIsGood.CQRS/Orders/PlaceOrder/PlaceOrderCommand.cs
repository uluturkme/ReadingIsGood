namespace ReadingIsGood.CQRS.Orders;

public class PlaceOrderCommand : IRequest<Response<PlaceOrderResponse>>
{
    public Guid CustomerId { get; set; }
    public List<OrderItems> Items { get; set; }
}