using Kiosk.Domain.Constants;
using Kiosk.DTOs.UserDTOs;
using Kiosk.Services.UserService.Interfaces;
using Kiosk.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            try
            {
                return Response(await _userService.Register(dto));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResponseDto>> Login(LoginDto dto)
        {
            try
            {
                var response = await _userService.Login(dto);
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (BadCredentialsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
