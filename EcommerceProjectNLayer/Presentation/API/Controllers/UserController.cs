
using Business.User;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;

        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string userName, string password)
        {
            var userId = userService.Login(userName, password);
            return Ok(new { userId });
        }

    }
}