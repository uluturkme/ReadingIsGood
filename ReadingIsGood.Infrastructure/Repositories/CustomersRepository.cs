namespace ReadingIsGood.Infrastructure.Repositories;

public class CustomersRepository : BaseRepository<Customers>, ICustomersRepository
{
    public CustomersRepository(ReadingIsGoodContext context) : base(context)
    {
    }

    public async Task<Customers> GetCustomerByEmail(string email)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }
}
