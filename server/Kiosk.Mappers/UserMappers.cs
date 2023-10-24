using Kiosk.Domain.Models;
using Kiosk.DTOs.UserDTOs;

namespace Kiosk.Mappers
{
    public static class UserMappers
    {
        public static UserLoginResponseDto ToLoginResponse(this User user, string token, string refreshToken)
        {
            return new UserLoginResponseDto
            {
                Username = user.UserName,
                Token = token,
                RefreshToken = refreshToken
            };
        }
    }
}
