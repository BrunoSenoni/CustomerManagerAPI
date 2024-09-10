using CustomerManager.Application.Commands.InsertCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Application.Validators
{
  public class InsertCustomerValidator : AbstractValidator<InsertCustomerCommand>
  {
    public InsertCustomerValidator()
    {
      RuleFor(p => p.FirstName)
      .NotEmpty()
      .WithMessage("Cannot be empty")
      .MaximumLength(50)
      .WithMessage("Max lenght is 20");

      RuleFor(p => p.LastName)
      .NotEmpty()
      .WithMessage("Cannot be empty")
      .MaximumLength(50)
      .WithMessage("Max lenght is 20");

      RuleFor(u => u.Email)
      .EmailAddress()
      .WithMessage("invalid email address");
    }


  }
}
