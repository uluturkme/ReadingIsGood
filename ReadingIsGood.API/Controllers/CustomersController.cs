using Microsoft.AspNetCore.Mvc;

namespace ReadingIsGood.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomersController : BaseController
{
    private readonly IMediator _mediator;
    private readonly ILogger<CustomersController> _logger;

    public CustomersController(IMediator mediator, ILogger<CustomersController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest model)
    {
        var result = await _mediator.Send(new CreateCustomerCommand()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email
        });

        return MapToResult(result);
    }
}
