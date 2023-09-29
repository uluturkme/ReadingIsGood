namespace ReadingIsGood.Infrastructure;

public class ReadingIsGoodContext : DbContext
{
    public ReadingIsGoodContext(DbContextOptions<ReadingIsGoodContext> options) : base(options)
    {
    }
    
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Books> Books { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomersConfiguration());
        modelBuilder.ApplyConfiguration(new BooksConfiguration());
    }
}