using AuthenticationService.Domain.Entities;
using System.Threading.Tasks;

namespace AuthenticationService.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
