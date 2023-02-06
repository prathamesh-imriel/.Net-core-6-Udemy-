using StackExchange.Redis;

namespace Udemy_Api.Model.DTO
{
    public class User_Role
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public User User { get; set; }

        public StackExchange.Redis.Role Role { get; set; }
    }
}
