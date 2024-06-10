using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Order.Queries.GetAll
{
    public class GetAllOrderResponse: BaseResponse
    {
        public IEnumerable<GetAllOrderListVm> OrderList { get; set; }
    }
}
