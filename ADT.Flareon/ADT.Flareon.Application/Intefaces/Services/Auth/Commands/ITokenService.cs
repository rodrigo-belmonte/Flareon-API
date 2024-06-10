using ADT.Flareon.Application.Services.Auth.Commands.Login;
using ADT.Flareon.Application.ViewModels.User;

namespace ADT.Flareon.Application.Intefaces.Services.Auth.Commands
{
    public interface ITokenService
    {
        string GenerateToken(UserInfoVm user);
    }
}
