namespace ReadingIsGood.Domain.Books;

public interface IBooksRepository : IRepository<Books>
{
    Task<Books> GetBookByTitle(string title);
    void Update(Books book);

}