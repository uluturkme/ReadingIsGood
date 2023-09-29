namespace ReadingIsGood.Infrastructure.Repositories;

public class BooksRepository : BaseRepository<Books>, IBooksRepository
{
    public BooksRepository(ReadingIsGoodContext context) : base(context)
    {
    }

    public async Task<Books> GetBookByTitle(string title)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.Title == title);
    }
}
