using CustomerManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Application.ModelsDTO
{
  public class CustomerViewModel
  {
    public CustomerViewModel(int id, string firstName, string lastName, string email, DateTime? createdDate = null, DateTime? lastUpdatedDate = null)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      CreatedDate = createdDate;
      LastUpdatedDate = lastUpdatedDate;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LastUpdatedDate { get; set; }

    public static CustomerViewModel FromEntity(Customer entity) => new CustomerViewModel(entity.Id, entity.FirstName, entity.LastName, entity.Email, entity.CreatedDate, entity.LastUpdatedDate);
  }
}
