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

namespace ADT.Flareon.Application.Services.User.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, BaseResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ChangePasswordCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
			_mapper = mapper;
			_userRepository = userRepository;
        }

        public async Task<BaseResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                var user = await _userRepository.GetByIdAsync(Guid.Parse(request.Id));

                user.Password = request.Password;
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
