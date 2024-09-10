using CustomerManager.Application.ModelsDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Application.Queries.GetAllCustomers
{
  public class GetAllCustomersQuery : IRequest<ResultViewModel<List<CustomerViewModel>>>
  {
  }
}
