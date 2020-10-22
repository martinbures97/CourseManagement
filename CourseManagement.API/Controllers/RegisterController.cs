using CourseManagement.Application.User.CreateUserCommand;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseManagement.API.Controllers
{
    public class RegisterController : ApiController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}