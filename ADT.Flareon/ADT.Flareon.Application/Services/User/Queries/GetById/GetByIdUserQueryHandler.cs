using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;
using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.ViewModels.User;

namespace ADT.Flareon.Application.Services.User.Queries.GetById
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<UserTable> _userRepository;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;

        public GetByIdUserQueryHandler(IMapper mapper, IAsyncRepository<UserTable> userRepository, IAsyncRepository<EmployeeTable> employeeRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<GetByIdUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var response = new GetByIdUserResponse();

            try
            {
                var user = await _userRepository.GetByIdAsync(request.Id);
                response.User = _mapper.Map<GetByIdUserVm>(user);
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
