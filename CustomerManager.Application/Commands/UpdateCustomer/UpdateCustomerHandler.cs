using CustomerManager.Application.ModelsDTO;
using CustomerManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Application.Commands.UpdateCustomer
{
  public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, ResultViewModel>
  {
    private readonly ICustomerRepository _repository;
    public UpdateCustomerHandler(ICustomerRepository repository)
    {
      _repository = repository;
    }
    public async Task<ResultViewModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
      var customer = await _repository.GetCustomerByIdAsync(request.Id);
      var exists = await _repository.Exists(request.Id);

      if (!exists)
      {
        return ResultViewModel.Error("Customer does not exist");
      }

      customer.Update(request.FirstName, request.LastName, request.Email);
      await _repository.UpdateCustomerAsync(customer);

      return ResultViewModel.Success();


    }
  }
}
