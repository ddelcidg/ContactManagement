using AuthenticationService.Domain.Entities;
using System.Threading.Tasks;

namespace AuthenticationService.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}
