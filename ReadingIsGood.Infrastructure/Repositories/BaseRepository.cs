namespace ReadingIsGood.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : Entity
{
    protected readonly ReadingIsGoodContext _context;
    public BaseRepository(ReadingIsGoodContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
}
