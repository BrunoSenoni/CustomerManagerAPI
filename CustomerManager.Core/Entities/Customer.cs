namespace CustomerManager.Core.Entities
{
  public class Customer
  {
    public Customer()
    {
    }

    public Customer(string firstName, string lastName, string email, DateTime? createdDate = null, DateTime? lastUpdatedDate = null, int? id = null)
    {
    
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      CreatedDate = createdDate;  
      LastUpdatedDate = lastUpdatedDate;
      if (id.HasValue)
      {
        Id = id.Value;
      }
    }

    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LastUpdatedDate { get; private set; }
    public bool IsDeleted { get; set; } 


    public void Update(string firstName, string lastName, string email)
    {
      FirstName = firstName.Trim();
      LastName = lastName.Trim();
      Email = email.Trim();
      LastUpdatedDate = DateTime.Now;
    }
    public void SetAsDeleted()
    {
      IsDeleted = true;
    }

  }
}
