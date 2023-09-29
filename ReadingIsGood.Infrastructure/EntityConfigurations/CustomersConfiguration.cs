namespace ReadingIsGood.Infrastructure.EntityConfigurations;

public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
{
    public void Configure(EntityTypeBuilder<Customers> builder)
    {
        builder.ToTable(TableNames.Customers);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName);
        builder.Property(x => x.LastName);
        builder.Property(x => x.Email);
        builder.Property(x => x.CreatedOnUtc);
        builder.Property(x => x.UpdatedOnUtc);
    }
}