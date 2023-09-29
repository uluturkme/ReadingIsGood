namespace ReadingIsGood.Domain.Books;

public interface IBooksRepository: IRepository<Books>
{
    public Task<Books> GetBookByTitle(string title);
}