using CustomerManager.Application.ModelsDTO;
using MediatR;

namespace CustomerManager.Application.Commands.DeleteCustomer
{
  public class DeleteCustomerCommand : IRequest<ResultViewModel>
  {
    public DeleteCustomerCommand(int id)
    {
      Id = id;
    }
    public int Id { get; set; }
  }
}
