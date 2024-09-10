
using Microsoft.AspNetCore.Mvc;

using MediatR;
using CustomerManager.Application.Queries.GetAllCustomers;
using CustomerManager.Application.Commands.InsertCustomer;
using CustomerManager.Application.Commands.UpdateCustomer;
using CustomerManager.Application.Commands.DeleteCustomer;


namespace CustomerManager.API.Controllers
{
  [Route("api/customers")]
  [ApiController]
  public class ProjectsController : ControllerBase
  {
    private readonly IMediator _mediator;
    public ProjectsController(IMediator mediator)
    {
      _mediator = mediator;

    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var query = new GetAllCustomersQuery();
      var result = await _mediator.Send(query);
      return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Post(InsertCustomerCommand command)
    {
      var result = await _mediator.Send(command);
      if (!result.IsSuccess)
      {
        return BadRequest(result.Message);
      }
      return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateCustomerCommand command)
    {
      command.Id = id;
      var result = await _mediator.Send(command);

      if (!result.IsSuccess)
      {

        return BadRequest(result.Message);
      }


      return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      
      var result = await _mediator.Send(new DeleteCustomerCommand(id));

      if (!result.IsSuccess)
      {

        return BadRequest(result.Message);
      }


      return NoContent();
    }
  }
}
