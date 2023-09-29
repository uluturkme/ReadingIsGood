namespace ReadingIsGood.API.Models;

public class PlaceOrderRequest
{
    public Guid CustomerId { get; set; }
    public List<OrderItem> Items { get; set; }
}

public class OrderItem
{
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
}
