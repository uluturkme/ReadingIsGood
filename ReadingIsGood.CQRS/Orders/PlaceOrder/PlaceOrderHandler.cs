namespace ReadingIsGood.CQRS.Orders;

public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, Response<PlaceOrderResponse>>
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IBooksRepository _booksRepository;
    private readonly ICustomersRepository _customersRepository;
    private readonly ReadingIsGoodContext _context;

    public PlaceOrderHandler(IOrdersRepository ordersRepository, IBooksRepository booksRepository,
        ICustomersRepository customersRepository, ReadingIsGoodContext context)
    {
        _ordersRepository = ordersRepository;
        _booksRepository = booksRepository;
        _customersRepository = customersRepository;
        _context = context;
    }

    public async Task<Response<PlaceOrderResponse>> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customersRepository.GetByIdAsync(request.CustomerId);
        if (customer == null)
        {
            return Response<PlaceOrderResponse>.Fail("Customer is not exist.");
        }

        if (request.Items.Count(i => i.Quantity <= 0) > 0)
        {
            return Response<PlaceOrderResponse>.Fail("Wrong quantity.");
        }

        var order = new Domain.Orders.Orders();
        var orderItems = new List<OrderItems>();
        decimal totalPrice = 0;
        foreach (var item in request.Items)
        {
            var book = await _booksRepository.GetByIdAsync(item.BookId);
            if (book == null)
            {
                return Response<PlaceOrderResponse>.Fail("Book is not exist. Id: " + item.BookId);
            }

            if (book.Quantity < item.Quantity)
            {
                return Response<PlaceOrderResponse>.Fail("No stock for book: " + book.Title);
            }

            totalPrice += book.Price * item.Quantity;
            orderItems.Add(item);
            book.Quantity -= item.Quantity;
            _booksRepository.Update(book);
        }
        order.TotalPrice = totalPrice;
        await _ordersRepository.PlaceOrder(order, orderItems);
        await _context.SaveChangesAsync();

        return Response<PlaceOrderResponse>.Success(new PlaceOrderResponse()
        {
            OrderId = order.Id,
            TotalPrice = order.TotalPrice
        });
    }
}
