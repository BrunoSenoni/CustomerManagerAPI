using CustomerManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerManager.Infrastructure.Persistence
{
  public class CustomerDbContext : DbContext
  {
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Customer>(entity =>
      {
        entity.HasKey(c => c.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(c => c.FirstName)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(c => c.LastName)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(c => c.Email)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(c => c.CreatedDate);


        entity.Property(c => c.LastUpdatedDate);
              
      });

            // Seed 20 customers into the database
            builder.Entity<Customer>().HasData(
                new Customer("John", "Doe", "john.doe@example.com", DateTime.Now, null, 1),
                new Customer("Jane", "Smith", "jane.smith@example.com", DateTime.Now, null, 2),
                new Customer("Michael", "Johnson", "michael.johnson@example.com", DateTime.Now, null, 3),
                new Customer("Emily", "Davis", "emily.davis@example.com", DateTime.Now, null, 4),
                new Customer("William", "Brown", "william.brown@example.com", DateTime.Now, null, 5),
                new Customer("Olivia", "Wilson", "olivia.wilson@example.com", DateTime.Now, null, 6),
                new Customer("James", "Taylor", "james.taylor@example.com", DateTime.Now, null, 7),
                new Customer("Sophia", "Anderson", "sophia.anderson@example.com", DateTime.Now, null, 8),
                new Customer("Benjamin", "Thomas", "benjamin.thomas@example.com", DateTime.Now, null, 9),
                new Customer("Amelia", "Moore", "amelia.moore@example.com", DateTime.Now, null, 10),
                new Customer("Mason", "Jackson", "mason.jackson@example.com", DateTime.Now, null, 11),
                new Customer("Isabella", "White", "isabella.white@example.com", DateTime.Now, null, 12),
                new Customer("Elijah", "Harris", "elijah.harris@example.com", DateTime.Now, null, 13),
                new Customer("Charlotte", "Martin", "charlotte.martin@example.com", DateTime.Now, null, 14),
                new Customer("Lucas", "Thompson", "lucas.thompson@example.com", DateTime.Now, null, 15),
                new Customer("Mia", "Garcia", "mia.garcia@example.com", DateTime.Now, null, 16),
                new Customer("Henry", "Martinez", "henry.martinez@example.com", DateTime.Now, null, 17),
                new Customer("Harper", "Robinson", "harper.robinson@example.com", DateTime.Now, null, 18),
                new Customer("Alexander", "Clark", "alexander.clark@example.com", DateTime.Now, null, 19),
                new Customer("Ava", "Rodriguez", "ava.rodriguez@example.com", DateTime.Now, null, 20)
            );


            base.OnModelCreating(builder);
    }
  }
}
