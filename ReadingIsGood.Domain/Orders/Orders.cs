namespace ReadingIsGood.Domain.Orders;

public class Orders : Entity
{
    public Guid CustomerId { get; set; }
    public decimal TotalPrice { get; set; }

}
