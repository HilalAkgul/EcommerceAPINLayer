
using System.ComponentModel.DataAnnotations;
using Business.User;
using Dtos;
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
        public IActionResult Login(LoginDto dto)
        {
            throw new ApplicationException("Invalid Token");

            var result = userService.Login(dto.userName, dto.password);
            return Ok(result);
        }

    }
}