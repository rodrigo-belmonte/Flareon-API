using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Product.Queries.GetAll
{
    public class GetAllProductResponse: BaseResponse
    {
        public IEnumerable<ProductVm> ProductList { get; set; }
    }
}
