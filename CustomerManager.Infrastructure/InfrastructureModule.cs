using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CustomerManager.Infrastructure.Persistence;
using CustomerManager.Core.Repositories;
using CustomerManager.Infrastructure.Persistence.Repositories;

namespace CustomerManager.Infrastructure
{
  public static class InfrastructureModule
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddRepositories();
      services.AddData();
      return services;
    }

    private static IServiceCollection AddData(this IServiceCollection services)
    {
     
      services.AddDbContext<CustomerDbContext>(options =>
          options.UseInMemoryDatabase("CustomerInMemoryDb"));

      return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
      services.AddScoped<ICustomerRepository, CustomerRepository>();
      return services;
    }
  }
}
