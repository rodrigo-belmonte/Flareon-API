using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Employee.Queries.GetAll
{
    public class GetAllEmployeeResponse: BaseResponse
    {
        public IEnumerable<GetAllEmployeeListVm> EmployeeList { get; set; }
    }
}
