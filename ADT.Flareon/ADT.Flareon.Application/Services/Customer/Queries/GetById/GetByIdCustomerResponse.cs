using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Customer.Queries.GetById
{
    public class GetByIdCustomerResponse: BaseResponse
    {
        public GetByIdCustomerVm Customer { get; set; }
    }
}
