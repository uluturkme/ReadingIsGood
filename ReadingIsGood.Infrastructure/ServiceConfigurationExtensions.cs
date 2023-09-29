namespace ReadingIsGood.Infrastructure;

public static class ServiceConfigurationExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICustomersRepository, CustomersRepository>();
        services.AddScoped<IBooksRepository, BooksRepository>();
        services.AddScoped<IOrdersRepository, OrdersRepository>();
    }
}