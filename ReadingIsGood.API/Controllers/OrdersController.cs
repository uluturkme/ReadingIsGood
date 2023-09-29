using Microsoft.AspNetCore.Http.Features;

namespace ReadingIsGood.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController: BaseController
{
    private readonly IMediator _mediator;
    private readonly ILogger<CustomersController> _logger;

    public OrdersController(IMediator mediator, ILogger<CustomersController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("PlaceOrder")]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderRequest model)
    {
        var command = new PlaceOrderCommand()
        {
            CustomerId = model.CustomerId,
            Items = new List<Domain.Orders.OrderItems>()
        };
        model.Items.ForEach(i => command.Items.Add(new Domain.Orders.OrderItems(){
            BookId = i.BookId,
            Quantity = i.Quantity
        }));
        var result = await _mediator.Send(command);

        return MapToResult(result);
    }
}