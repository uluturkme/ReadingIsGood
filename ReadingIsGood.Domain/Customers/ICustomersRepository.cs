namespace ReadingIsGood.Domain.Customers;

public interface ICustomersRepository : IRepository<Customers>
{
    public Task<Customers> GetCustomerByEmail(string email);
}