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

namespace ADT.Flareon.Application.Services.User.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<UserTable> _userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IAsyncRepository<UserTable> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                var user = _mapper.Map<UserTable>(request);
                user.DtLastUpdate = DateTime.Now;

                await _userRepository.UpdateAsync(user);
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
