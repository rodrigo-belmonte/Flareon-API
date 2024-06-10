using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Order.Queries.GetById
{
    public class GetByIdOrderResponse: BaseResponse
    {
        public GetByIdOrderVm Order { get; set; }
    }
}
