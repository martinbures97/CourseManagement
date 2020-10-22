using CourseManagement.API.Models;
using CourseManagement.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseManagement.API.Controllers
{
    public class LoginController : ApiController
    {
        private readonly LoginService _loginService;

        public LoginController(
            LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginUserCommand request)
        {
            if (request == null)
                return BadRequest();

            var result = await _loginService.LoginAsync(request);
            if (result is null)
                return Unauthorized();

            return Ok(result);
        }
    }
}