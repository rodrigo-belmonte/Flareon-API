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

namespace ADT.Flareon.Application.Services.User.Queries.GetAll
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, GetAllUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<UserTable> _userRepository;

        public GetAllUserQueryHandler(IMapper mapper, IAsyncRepository<UserTable> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetAllUserResponse> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllUserResponse();

            try
            {
                var userList = await _userRepository.ListAllAsync();
                response.UserList = _mapper.Map<List<GetAllUserListVm>>(userList);
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
