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

namespace ADT.Flareon.Application.Services.Employee.Queries.GetById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;

        public GetEmployeeByIdQueryHandler(IMapper mapper, IAsyncRepository<EmployeeTable> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetEmployeeByIdResponse();

            try
            {
                var employee = await _employeeRepository.GetByIdAsync(request.Id);
                response.Employee = _mapper.Map<GetByIdEmployeeVm>(employee);
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
