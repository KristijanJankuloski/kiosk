using Kiosk.Domain.Constants;
using Kiosk.Domain.Models;
using Kiosk.DTOs.UserDTOs;
using Kiosk.Mappers;
using Kiosk.Services.UserService.Interfaces;
using Kiosk.Shared.Exceptions;
using Kiosk.Shared.Response;
using Microsoft.AspNetCore.Identity;

namespace Kiosk.Services.UserService.Implementaitons
{
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        public UserService(ITokenService tokenService, UserManager<User> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<UserLoginResponseDto> Login(LoginDto dto)
        {
            User user = await _userManager.FindByNameAsync(dto.Username) ?? throw new BadCredentialsException();

            bool result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!result) throw new BadCredentialsException();

            string token = _tokenService.GenerateToken(user);
            string refreshToken = await _tokenService.GenerateRefreshTokenAsync(user);
            return user.ToLoginResponse(token, refreshToken);
        }

        public async Task<UserLoginResponseDto> RefreshToken()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Register(UserRegisterDto dto)
        {
            if (dto.Password != dto.PasswordConfirm) return new Response("Password does not match");

            User newUser = new User
            {
                UserName = dto.Username,
                Email = dto.Email,
            };
            var result = await _userManager.CreateAsync(newUser, dto.Password);
            await _userManager.AddToRoleAsync(newUser, Roles.User);

            if (result.Succeeded) return Response.Success;
            return new Response(result.Errors.Select(e => e.Description).ToList());
        }
    }
}
