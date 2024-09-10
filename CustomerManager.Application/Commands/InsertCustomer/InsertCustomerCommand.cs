using CustomerManager.Core.Entities;
using MediatR;
using CustomerManager.Application.ModelsDTO;

namespace CustomerManager.Application.Commands.InsertCustomer
{
  public class InsertCustomerCommand : IRequest<ResultViewModel<int>>
  {
    public InsertCustomerCommand(string firstName, string lastName, string email)
    {
      FirstName = firstName;
      LastName = lastName;
      Email = email;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public Customer ToEntity() => new(FirstName, LastName, Email);
  }
}
