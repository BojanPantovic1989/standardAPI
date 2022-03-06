using Microsoft.AspNetCore.Mvc;
using standardAPI.Configuration;
using standardAPI.Models;
using standardAPI.Services;

namespace standardAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly AppSettings appSettings;

        public LoginController(IUserService userService, ITokenService tokenService, AppSettings appSettings)
        {
            this.userService = userService;
            this.tokenService = tokenService;
            this.appSettings = appSettings;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserDto user)
        {
            var userDto = userService.GetUser(user.UserName, user.Password);
            if (userDto == null)
            {
                return new UnauthorizedResult();                
            }

            var token = tokenService.BuildToken(appSettings.Jwt.Key, appSettings.Jwt.Issuer, appSettings.Jwt.Audience, userDto);
            return new OkObjectResult(new
            {
                token
            });
        }
    }
}
