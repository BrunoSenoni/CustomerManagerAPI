using CustomerManager.Core.Entities;
using CustomerManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManager.Infrastructure.Persistence.Repositories
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly CustomerDbContext _dbContext;

    public CustomerRepository(CustomerDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // Add a new customer
    public async Task AddCustomerAsync(Customer customer)
    {
      _dbContext.Customers.Add(customer);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
      return await _dbContext.Customers.Where(c => !c.IsDeleted).ToListAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
      return await _dbContext.Customers.FindAsync(id);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
      _dbContext.Customers.Update(customer);
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int id)
    {
      var customer = await _dbContext.Customers.FindAsync(id);
      if (customer != null)
      {
        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();
      }
    }

    public async Task<bool> Exists(int id)
    {
      return await _dbContext.Customers.AnyAsync(p => p.Id == id);
    }
  }
}
