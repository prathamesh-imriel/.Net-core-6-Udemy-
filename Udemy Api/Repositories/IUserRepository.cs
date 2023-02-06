
using Udemy_Api.Model.DTO;

namespace Udemy_Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
