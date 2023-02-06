using Microsoft.AspNetCore.Mvc;
using Udemy_Api.Repositories;

namespace Udemy_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {

        private readonly IUserRepository userRepository;
        private readonly ITokenHandeller tokenHandeller;

        public AuthController(IUserRepository userRepository, ITokenHandeller tokenHandeller)
        {
            this.userRepository = userRepository;
            this.tokenHandeller = tokenHandeller;
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(Model.DTO.LoginRequest request)
        {
            var user = await userRepository.AuthenticateAsync(request.UserName, request.Password);

            if (user!=null)
            {
               var token =  await tokenHandeller.CreateTokenAsync(user);
                return Ok(token);
            }



            return BadRequest("UserName and password is incorrect");
        }
    }
}
