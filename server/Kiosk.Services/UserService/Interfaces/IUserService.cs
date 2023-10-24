using Kiosk.DTOs.UserDTOs;
using Kiosk.Shared.Response;

namespace Kiosk.Services.UserService.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginResponseDto> Login(LoginDto dto);
        Task<UserLoginResponseDto> RefreshToken();
        Task<Response> Register(UserRegisterDto dto);
    }
}
