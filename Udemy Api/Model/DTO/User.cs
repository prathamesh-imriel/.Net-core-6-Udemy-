namespace Udemy_Api.Model.DTO
{
    public class User
    {

        public Guid Id { get; set; }

        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }

        public List<string> Roles { get; set; } 

    }
}
