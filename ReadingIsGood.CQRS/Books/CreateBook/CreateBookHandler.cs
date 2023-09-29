namespace ReadingIsGood.CQRS.Books;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, Response<CreateBookResponse>>
{
    private readonly IBooksRepository _booksRepository;

    public CreateBookHandler(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<Response<CreateBookResponse>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _booksRepository.GetBookByTitle(request.Title);
        if (book != null)
        {
            return Response<CreateBookResponse>.Fail("Book exist");
        }

        book = await _booksRepository.AddAsync(new Domain.Books.Books(request.Title, request.Description, request.Price, request.Quantity));

        return Response<CreateBookResponse>.Success(new CreateBookResponse()
        {
            BookId = book.Id
        });
    }
}
