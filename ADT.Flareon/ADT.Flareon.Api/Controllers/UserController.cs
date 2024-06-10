using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.Services.User.Commands.Create;
using ADT.Flareon.Application.Services.User.Commands.Delete;
using ADT.Flareon.Application.Services.User.Commands.Update;
using ADT.Flareon.Application.Services.User.Queries.GetAll;
using ADT.Flareon.Application.Services.User.Queries.GetById;
using ADT.Flareon.Application.Services.User.Queries.GetProfile;
using ADT.Flareon.Application.Services.User.Commands.ChangePassword;

namespace ADT.Flareon.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllUserResponse>>> GetUsers()
        {
            var response = await _mediator.Send(new GetAllUserQuery());
            return Ok(response);
        }


        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetByIdUserResponse>> GetUserById(Guid Id)
        {
            var getUserByIdQuery = new GetByIdUserQuery() { Id = Id };
            var response = await _mediator.Send(getUserByIdQuery);

            return Ok(response);
        }

        [HttpPost( Name = "NewUser")]
        public async Task<ActionResult<BaseResponse>> NewUser([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);

            return Ok(response);
        }

        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            var response = await _mediator.Send(updateUserCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> DeleteUser(Guid Id)
        {
            var deleteUserCommand = new DeleteUserCommand() { Id = Id };
            var response = await _mediator.Send(deleteUserCommand);
            return Ok(response);
        }
        
        [HttpGet("GetProfileById/{id}", Name = "GetProfileById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetProfileResponse>> GetProfileById(Guid Id)
        {
            var getUserByIdQuery = new GetProfileQuery() { Id = Id };
            var response = await _mediator.Send(getUserByIdQuery);

            return Ok(response);
        }

        [HttpPut("ChangePassword", Name = "ChangePassword")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> ChangePassword([FromBody] ChangePasswordCommand changePasswordCommand)
        {
            var response = await _mediator.Send(changePasswordCommand);
            return Ok(response);
        }
    }
}
