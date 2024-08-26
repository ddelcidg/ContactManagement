using MediatR;
using AuthenticationService.Domain.Entities;
using AuthenticationService.Domain.Interfaces;
using AuthenticationService.Domain.Services;
using System.Threading;
using System.Threading.Tasks;
using AuthenticationService.Application.Commands.Authentication;

namespace AuthenticationService.Application.Handlers.Authentication
{
    public class LoginHandler : IRequestHandler<LoginCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;

        public LoginHandler(IUserRepository userRepository, PasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null || !_passwordHasher.VerifyPassword(user.PasswordHash, request.Password))
            {
                return null; // O lanzar una excepción
            }
            return user;
        }
    }
}
