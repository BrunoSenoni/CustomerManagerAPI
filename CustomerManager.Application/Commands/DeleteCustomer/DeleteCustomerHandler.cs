

using CustomerManager.Application.ModelsDTO;
using CustomerManager.Core.Repositories;
using MediatR;

namespace CustomerManager.Application.Commands.DeleteCustomer
{
  public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, ResultViewModel>
  {
    private readonly ICustomerRepository _repository;
    public DeleteCustomerHandler(ICustomerRepository repository)
    {
      _repository = repository;
    }
    public async Task<ResultViewModel> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
      var customer = await _repository.GetCustomerByIdAsync(request.Id);
      var exists = await _repository.Exists(request.Id);

      if (!exists)
      {
        return ResultViewModel.Error("Customer does not exist");
      }
      //perform soft deletion
      customer.SetAsDeleted();

      await _repository.UpdateCustomerAsync(customer);

      return ResultViewModel.Success();

    }
  }
}
