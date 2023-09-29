namespace ReadingIsGood.CQRS.Customers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Response<CreateCustomerResponse>>
{
    private readonly ICustomersRepository _customersRepository;

    public CreateCustomerHandler(ICustomersRepository customersRepository)
    {
        _customersRepository = customersRepository;
    }

    public async Task<Response<CreateCustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customersRepository.GetCustomerByEmail(request.Email);
        if (customer != null)
        {
            return Response<CreateCustomerResponse>.Fail("Email address is using.");
        }

        customer = await _customersRepository.AddAsync(new Domain.Customers.Customers(request.FirstName, request.LastName, request.Email));

        return Response<CreateCustomerResponse>.Success(new CreateCustomerResponse()
        {
            CustomerId = customer.Id
        });
    }
}
