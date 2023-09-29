namespace ReadingIsGood.Domain;

public interface IRepository<T> where T : Entity
{
    Task<T> AddAsync(T entity);
}