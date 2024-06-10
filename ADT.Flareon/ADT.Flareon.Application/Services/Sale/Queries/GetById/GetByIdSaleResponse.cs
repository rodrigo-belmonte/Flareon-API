using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.ViewModels.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Sale.Queries.GetById
{
    public class GetByIdSaleResponse: BaseResponse
    {
        public GetByIdSaleVm Sale { get; set; }
    }
}
