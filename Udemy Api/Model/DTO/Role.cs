namespace Udemy_Api.Model.DTO
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        List<User_Role> UserRoles { get; set; }

    }
}
