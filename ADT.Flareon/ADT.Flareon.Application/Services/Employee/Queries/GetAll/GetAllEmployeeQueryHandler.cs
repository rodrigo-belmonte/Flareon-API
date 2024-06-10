using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;
using ADT.Flareon.Application.ViewModels.Employee;

namespace ADT.Flareon.Application.Services.Employee.Queries.GetAll
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, GetAllEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;

        public GetAllEmployeeQueryHandler(IMapper mapper, IAsyncRepository<EmployeeTable> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<GetAllEmployeeResponse> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllEmployeeResponse();

            try
            {
                var employeeList = await _employeeRepository.ListAllAsync();
                response.EmployeeList = _mapper.Map<List<GetAllEmployeeListVm>>(employeeList);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ValidationErrors = new List<string> { ex.Message };
            }

            return response;
        }
    }
}
