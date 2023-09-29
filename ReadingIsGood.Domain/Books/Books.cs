namespace ReadingIsGood.Domain.Books;

public class Books : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Books(string title, string description, decimal price, int quantity) : base()
    {
        Title = title;
        Description = description;
        Price = price;
        Quantity = quantity;
    }
}