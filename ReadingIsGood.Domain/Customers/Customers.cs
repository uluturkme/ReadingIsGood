namespace ReadingIsGood.Domain.Customers;

public class Customers : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public Customers(string firstName, string lastName, string email) : base()
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}