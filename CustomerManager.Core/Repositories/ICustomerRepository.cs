using CustomerManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Core.Repositories
{
  public interface ICustomerRepository
  {
    Task AddCustomerAsync(Customer customer);
    Task<List<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(int id);
    Task<bool> Exists(int id);

  }
}
