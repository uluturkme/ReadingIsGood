namespace ReadingIsGood.Infrastructure.Repositories;

public class OrdersRepository : BaseRepository<Orders>, IOrdersRepository
{
    public OrdersRepository(ReadingIsGoodContext context) : base(context)
    {
    }

    public async Task<Orders> PlaceOrder(Orders order, List<OrderItems> items)
    {
        await _context.AddAsync<Orders>(order);

        foreach (var item in items)
        {
            item.OrderId = order.Id;
            await _context.AddAsync<OrderItems>(item);
        }
        await _context.SaveChangesAsync();
        return order;
    }
}
