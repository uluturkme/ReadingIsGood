namespace ReadingIsGood.API.Models;

public class CreateBookRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
