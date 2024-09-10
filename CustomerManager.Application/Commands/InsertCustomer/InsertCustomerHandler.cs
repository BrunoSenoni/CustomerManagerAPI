using CustomerManager.Core.Repositories;
using CustomerManager.Application.ModelsDTO;
using MediatR;

namespace CustomerManager.Application.Commands.InsertCustomer
{
  public class InsertCustomerHandler : IRequestHandler<InsertCustomerCommand, ResultViewModel<int>>
  {
    private readonly ICustomerRepository _repository;
    public InsertCustomerHandler(ICustomerRepository repository)
    {
      _repository = repository;
    }
    public async Task<ResultViewModel<int>> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
    {
      var customer = request.ToEntity();
      customer.CreatedDate = DateTime.Now;
      await _repository.AddCustomerAsync(customer);
      return ResultViewModel<int>.Success(customer.Id);

    }
  }
}
