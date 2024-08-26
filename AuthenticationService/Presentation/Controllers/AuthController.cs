using MediatR;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Application.Commands.Authentication;
using AuthenticationService.Presentation.Models;
using System.Threading.Tasks;

namespace AuthenticationService.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var command = new LoginCommand
            {
                Username = loginRequest.Username,
                Password = loginRequest.Password
            };

            var user = await _mediator.Send(command);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            return Ok(new LoginResponse
            {
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email
            });
        }
    }
}
