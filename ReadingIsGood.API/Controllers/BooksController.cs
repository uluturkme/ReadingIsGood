namespace ReadingIsGood.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BooksController: BaseController
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest model)
    {
        var result = await _mediator.Send(new CreateBookCommand()
        {
            Title = model.Title,
            Description = model.Description,
            Price = model.Price,
            Quantity = model.Quantity
        });

        return MapToResult(result);
    }
}
