using MediatR;
using ADT.Flareon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Auth.Commands.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
