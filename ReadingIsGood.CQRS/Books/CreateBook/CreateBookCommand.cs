namespace ReadingIsGood.CQRS.Books;

public class CreateBookCommand : IRequest<Response<CreateBookResponse>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
