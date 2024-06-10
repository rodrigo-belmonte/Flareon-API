using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADT.Flareon.Application.Responses;
using AutoMapper;
using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;

namespace ADT.Flareon.Application.Services.Employee.Commands.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;

        public UpdateEmployeeCommandHandler(IMapper mapper, IAsyncRepository<EmployeeTable> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<BaseResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                var employee = _mapper.Map<EmployeeTable>(request);
                employee.DtLastUpdate = DateTime.Now;

                await _employeeRepository.UpdateAsync(employee);
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
