using AuthenticationService.Domain.Entities;
using MediatR;

namespace AuthenticationService.Application.Commands.Authentication
{
    public class LoginCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
