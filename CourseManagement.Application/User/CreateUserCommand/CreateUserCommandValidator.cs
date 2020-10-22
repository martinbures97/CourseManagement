using CourseManagement.Application.Validation;
using FluentValidation;

namespace CourseManagement.Application.User.CreateUserCommand
{
    public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 50);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Length(5, 50)
                .Must(CustomValidation.CheckWhiteSpace)
                .WithMessage("Can't contain whitespaces.");

            RuleFor(x => x.ReEmail)
                .NotEmpty()
                .Equal(x => x.Email)
                .EmailAddress()
                .Must(CustomValidation.CheckWhiteSpace)
                .WithMessage("Can't contain whitespaces.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .Must(CustomValidation.CheckWhiteSpace)
                .WithMessage("Can't contain whitespaces.");

            RuleFor(x => x.RePassword)
                .NotEmpty()
                .Equal(x => x.Password)
                .Must(CustomValidation.CheckWhiteSpace)
                .WithMessage("Cant't contain whitespaces.");
        }
    }
}