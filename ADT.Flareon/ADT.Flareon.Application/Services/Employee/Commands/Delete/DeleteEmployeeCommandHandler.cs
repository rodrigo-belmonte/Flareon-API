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

namespace ADT.Flareon.Application.Services.Employee.Commands.Delete
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;

        public DeleteEmployeeCommandHandler(IMapper mapper, IAsyncRepository<EmployeeTable> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<BaseResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                await _employeeRepository.DeleteAsync(request.Id);
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
