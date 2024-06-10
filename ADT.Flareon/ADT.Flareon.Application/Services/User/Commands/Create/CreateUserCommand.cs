using MediatR;
using ADT.Flareon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.User.Commands.Create
{
    public class CreateUserCommand : IRequest<BaseResponse>
    {
         public Guid EmployeeId { get; set; }
        public string Name{ get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
