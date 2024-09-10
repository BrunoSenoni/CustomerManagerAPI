using CustomerManager.Application.ModelsDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Application.Commands.UpdateCustomer
{
  public class UpdateCustomerCommand: IRequest<ResultViewModel>
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
  }
}
