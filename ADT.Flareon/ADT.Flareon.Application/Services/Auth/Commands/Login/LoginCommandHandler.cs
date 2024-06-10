using MediatR;
using ADT.Flareon.Application.Intefaces.Services.Auth.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Domain.Tables;
using AutoMapper;
using ADT.Flareon.Application.ViewModels.User;
using ADT.Flareon.Application.Enums;

namespace ADT.Flareon.Application.Services.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(IMapper mapper, ITokenService tokenService, IUserRepository userRepository)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginCommandResponse = new LoginCommandResponse();
            try
            {
                var user = await _userRepository.Login(request.User);

                if (user.Password != request.Password)
                {
                    loginCommandResponse.Message = "Usuário / Senha incorretos";
                }
                else
                {
                    var userInfo = _mapper.Map<UserInfoVm>(user);
                    loginCommandResponse.UserInfo = userInfo;
                    loginCommandResponse.Token = _tokenService.GenerateToken(userInfo);
                }
            }
            catch (Exception ex)
            {
                loginCommandResponse.Success = false;
                loginCommandResponse.ValidationErrors = new List<string>();
                loginCommandResponse.ValidationErrors.Add(ex.Message);
            }

            return loginCommandResponse;
        }
    }
}
