using System.Threading;
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

namespace ADT.Flareon.Application.Services.User.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse>
    {
        private readonly IAsyncRepository<UserTable> _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IMapper mapper, IAsyncRepository<UserTable> userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                var user = _mapper.Map<UserTable>(request);
                user.Id = Guid.NewGuid();
                user.DtCreation = DateTime.Now;
                user.DtLastUpdate = DateTime.Now;
                await _userRepository.AddAsync(user);
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
