using Udemy_Api.Model.DTO;

namespace Udemy_Api.Repositories
{
    public interface ITokenHandeller
    {
        Task<string> CreateTokenAsync(User user);
    }
}
