using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADT.Flareon.Domain.Tables;
using ADT.Flareon.Application.Intefaces.Persistence;
using AutoMapper;
using ADT.Flareon.Application.Responses;

namespace ADT.Flareon.Application.Services.Employee.Commands.Create
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;

        public CreateEmployeeCommandHandler(IMapper mapper, IAsyncRepository<EmployeeTable> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<BaseResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                var employee = _mapper.Map<EmployeeTable>(request);
                employee.Id = Guid.NewGuid();
                employee.DtCreation = DateTime.Now;
                employee.DtLastUpdate = DateTime.Now;

                await _employeeRepository.AddAsync(employee);
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
