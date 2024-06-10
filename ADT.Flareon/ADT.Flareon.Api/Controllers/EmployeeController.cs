using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.Services.Employee.Commands.Create;
using ADT.Flareon.Application.Services.Employee.Commands.Delete;
using ADT.Flareon.Application.Services.Employee.Commands.Update;
using ADT.Flareon.Application.Services.Employee.Queries.GetAll;
using ADT.Flareon.Application.Services.Employee.Queries.GetById;

namespace ADT.Flareon.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IMediator mediator, ILogger<EmployeeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet(Name = "GetEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllEmployeeResponse>>> GetEmployes()
        {
            var response = await _mediator.Send(new GetAllEmployeeQuery());
            return Ok(response);
        }


        [HttpGet("{id}", Name = "GetEmployeeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetEmployeeByIdResponse>> GetEmployeeById(Guid Id)
        {
            var getCustomerByIdQuery = new GetEmployeeByIdQuery() { Id = Id };
            var response = await _mediator.Send(getCustomerByIdQuery);

            return Ok(response);
        }

        [HttpPost(Name = "NewEmployee")]
        public async Task<ActionResult<BaseResponse>> NewEmployee([FromBody] CreateEmployeeCommand createEmployeeCommand)
        {
            var response = await _mediator.Send(createEmployeeCommand);

            return Ok(response);
        }

        [HttpPut(Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        {
            var response = await _mediator.Send(updateEmployeeCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteEmployee(Guid Id)
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand() { Id = Id };
            var response = await _mediator.Send(deleteEmployeeCommand);
            return Ok(response);
        }
    }
}
