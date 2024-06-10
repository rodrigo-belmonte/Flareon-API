using MediatR;
using ADT.Flareon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.User.Commands.Delete
{
    public class DeleteUserCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }

    }
}
