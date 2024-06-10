using MediatR;
using Microsoft.AspNetCore.Mvc;
using ADT.Flareon.Application.Services.Auth.Commands.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController: Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginCommandResponse>> Login([FromBody] LoginCommand loginCommand)
        {
            var response = await _mediator.Send(loginCommand);
            return Ok(response);
        }
    }
}
