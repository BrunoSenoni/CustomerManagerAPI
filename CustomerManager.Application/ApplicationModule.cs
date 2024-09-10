using CustomerManager.Application.Commands.InsertCustomer;
using CustomerManager.Application.ModelsDTO;
using CustomerManager.Application.Queries.GetAllCustomers;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;

using Microsoft.Extensions.DependencyInjection;


namespace CustomerManager.Application
{
  public static class ApplicationModule
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      services.AddHandlers();
      services.AddValidation();
      return services;
    }


    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
      services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertCustomerCommand>());
      //services.AddTransient<IPipelineBehavior<InsertCustomerCommand, ResultViewModel<int>>>();
      return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
      services
        .AddFluentValidationAutoValidation()
        .AddValidatorsFromAssemblyContaining<GetAllCustomersQuery>();


      return services;
    }

  }
}
