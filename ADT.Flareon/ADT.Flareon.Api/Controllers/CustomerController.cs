using MediatR;
using Microsoft.AspNetCore.Mvc;
using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.Services.Customer.Commands.Create;
using ADT.Flareon.Application.Services.Customer.Commands.Delete;
using ADT.Flareon.Application.Services.Customer.Commands.Update;
using ADT.Flareon.Application.Services.Customer.Queries.GetAll;
using ADT.Flareon.Application.Services.Customer.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;


        public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet(Name = "GetCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetAllCustomerResponse>> GetCustomers()
        {
            var response = await _mediator.Send(new GetAllCustomerQuery());
            return Ok(response);
        }


        [HttpGet("{id}", Name = "GetCustomerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetByIdCustomerResponse>> GetCustomerById(Guid Id)
        {
            var getCustomerByIdQuery = new GetByIdCustomerQuery() { Id = Id };
            var response = await _mediator.Send(getCustomerByIdQuery);

            return Ok(response);
        }

        [HttpPost( Name = "NewCustomer")]
        public async Task<ActionResult<BaseResponse>> NewCustomer([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var response = await _mediator.Send(createCustomerCommand);

            return Ok(response);
        }

        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            var response = await _mediator.Send(updateCustomerCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCustomer(Guid Id)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand() { Id = Id };
            var response = await _mediator.Send(deleteCustomerCommand);
            return Ok(response);
        }
    }
}
