namespace ReadingIsGood.Domain.Orders;

public class OrderItems : Entity
{
    public Guid OrderId { get; set; }
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
}
