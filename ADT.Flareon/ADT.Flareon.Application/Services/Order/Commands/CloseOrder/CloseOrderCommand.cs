using ADT.Flareon.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Order.Commands.CloseOrder
{
    public class CloseOrderCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
    }
}
