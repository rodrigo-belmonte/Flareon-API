using ADT.Flareon.Application.Responses;
using AutoMapper;
using ADT.Flareon.Domain.Tables;
using ADT.Flareon.Application.Intefaces.Persistence;
using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADT.Flareon.Application.ViewModels.User;

namespace ADT.Flareon.Application.Services.User.Queries.GetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EmployeeTable> _employeeRepository;

        public GetProfileQueryHandler(IMapper mapper, IUserRepository userRepository, IAsyncRepository<EmployeeTable> employeeRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<GetProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var response = new GetProfileResponse();

            try
            {
                var user = await _userRepository.GetByIdAsync(request.Id);
                var employee = await _employeeRepository.GetByIdAsync(user.EmployeeId);
                var profile = new GetProfileVm
                {
                    Id = user.Id,
                    UserName = user.Username,
                    Password = user.Password,
                    RoleName = user.RoleName,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    Telephone = employee.Telephone,
                    Email = employee.Email
                };
               
                response.Profile = profile;

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
