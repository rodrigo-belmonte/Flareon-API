using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.ViewModels.Order;
using ADT.Flareon.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Order.Queries.GetPiecesByOrderId
{
    public class GetPiecesByOrderIdResponse: BaseResponse
    {
        public int OrderNumber { get; set; }
        public IEnumerable<PieceClothingVm> Pieces { get; set; }

    }
}
