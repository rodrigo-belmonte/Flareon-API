using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.Auth.Commands.Login
{
    public class LoginCommandResponse: BaseResponse
    {
        public string Token { get; set; } = string.Empty;
        public UserInfoVm UserInfo { get; set; }
    }
}
