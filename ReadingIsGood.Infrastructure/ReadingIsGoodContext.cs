namespace ReadingIsGood.Infrastructure;

public class ReadingIsGoodContext : DbContext
{
    public ReadingIsGoodContext(DbContextOptions<ReadingIsGoodContext> options) : base(options)
    {
    }
    
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Books> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomersConfiguration());
        modelBuilder.ApplyConfiguration(new BooksConfiguration());
    }
}