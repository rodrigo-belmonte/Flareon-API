using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Employee.Queries.GetById
{
    public class GetEmployeeByIdResponse: BaseResponse
    {
        public GetByIdEmployeeVm Employee { get; set; }
    }
}
