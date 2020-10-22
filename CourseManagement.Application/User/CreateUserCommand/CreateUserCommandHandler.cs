using CourseManagement.Application.Abstraction;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.User.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, object>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(
            IUserService userService)
        {
            _userService = userService;
        }

        public async Task<object> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.CreateUserAsync(request.Email, request.Password, cancellationToken);
            return new
            {
                UserId = result
            };
        }
    }
}