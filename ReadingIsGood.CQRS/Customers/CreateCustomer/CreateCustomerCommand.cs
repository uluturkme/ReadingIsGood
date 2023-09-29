namespace ReadingIsGood.CQRS.Customers;

public class CreateCustomerCommand : IRequest<Response<CreateCustomerResponse>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
