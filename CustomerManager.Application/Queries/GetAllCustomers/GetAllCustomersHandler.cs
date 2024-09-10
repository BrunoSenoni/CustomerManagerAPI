using CustomerManager.Application.ModelsDTO;
using CustomerManager.Core.Repositories;
using MediatR;

namespace CustomerManager.Application.Queries.GetAllCustomers
{
  public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, ResultViewModel<List<CustomerViewModel>>>
  {
    private readonly ICustomerRepository _repository;
    public GetAllCustomersHandler(ICustomerRepository repository)
    {
      _repository = repository;
    }

    public async Task<ResultViewModel<List<CustomerViewModel>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
      var customers = await _repository.GetAllCustomersAsync();

      var model = customers.Select(CustomerViewModel.FromEntity).ToList();

      return ResultViewModel<List<CustomerViewModel>>.Success(model);
    }
  }
}
