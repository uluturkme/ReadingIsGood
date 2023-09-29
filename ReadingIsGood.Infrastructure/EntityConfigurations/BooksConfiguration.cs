namespace ReadingIsGood.Infrastructure.EntityConfigurations;

public class BooksConfiguration : IEntityTypeConfiguration<Books>
{
    public void Configure(EntityTypeBuilder<Books> builder)
    {
        builder.ToTable(TableNames.Books);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title);
        builder.Property(x => x.Description);
        builder.Property(x => x.Price);
        builder.Property(x => x.Quantity);
        builder.Property(x => x.CreatedOnUtc);
        builder.Property(x => x.UpdatedOnUtc);
    }
}