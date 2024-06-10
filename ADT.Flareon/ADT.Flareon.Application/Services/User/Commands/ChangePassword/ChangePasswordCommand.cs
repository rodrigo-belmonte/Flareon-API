using ADT.Flareon.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.User.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<BaseResponse>
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
