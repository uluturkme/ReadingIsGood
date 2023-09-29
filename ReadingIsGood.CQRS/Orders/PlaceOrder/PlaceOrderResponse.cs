namespace ReadingIsGood.CQRS.Orders;

public class PlaceOrderResponse
{
    public Guid OrderId { get; set; }
    public decimal TotalPrice { get; set; }
}
