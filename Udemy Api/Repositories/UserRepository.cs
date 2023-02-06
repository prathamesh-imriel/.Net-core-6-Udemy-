using Udemy_Api.Model.DTO;

namespace Udemy_Api.Repositories
{
    public class UserRepository : IUserRepository
    {

        private List<User> users = new List<User>() { new User() {
            FirstName="read only",LastName="User",
            EmailId="readonly@user.com",Id=new Guid(),
            UserName="readonly@gmail.com",
            Password="readonly123",
            Roles= new List<string>(){"reader"} },

        new User() {
            FirstName="read write",LastName="User",
            EmailId="readwrite@user.com",Id=new Guid(),
            UserName="readwrite@gmail.com",
            Password="readWrite123",
            Roles= new List<string>(){"writer","reader"} }
        };
        async Task<User> IUserRepository.AuthenticateAsync(string username, string password)
        {
            var user = users.Find(a=>a.UserName.Equals(username,StringComparison.InvariantCultureIgnoreCase) && a.Password==password);
            return user;
        }
    }
}
