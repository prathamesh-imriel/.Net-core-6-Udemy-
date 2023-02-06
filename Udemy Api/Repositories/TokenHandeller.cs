using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Udemy_Api.Model.DTO;

namespace Udemy_Api.Repositories
{
    public class TokenHandeller : ITokenHandeller
    {

        private readonly IConfiguration configuration;

        public TokenHandeller(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        Task<string> ITokenHandeller.CreateTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Email, user.EmailId)
            };

            user.Roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audiance"],
                claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
                );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
