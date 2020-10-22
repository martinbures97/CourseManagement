using MediatR;

namespace CourseManagement.Application.User.CreateUserCommand
{
    public sealed class CreateUserCommand : IRequest<object>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ReEmail { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}