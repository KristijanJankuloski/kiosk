using Kiosk.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ObjectResult InternalServerError(string? message = null)
        {
            return StatusCode(500, message?? "Internal server error occured");
        }

        protected IActionResult Response(Response response)
        {
            if(response.IsSuccessful)
            {
                return StatusCode(201, "Created");
            }

            return StatusCode(400, response);
        }
    }
}
