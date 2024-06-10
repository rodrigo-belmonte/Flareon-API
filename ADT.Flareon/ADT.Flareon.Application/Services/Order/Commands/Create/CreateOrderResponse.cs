using ADT.Flareon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Order.Commands.Create
{
    public class CreateOrderResponse: BaseResponse
    {
        public Guid OrderId { get; set; }

    }
}
