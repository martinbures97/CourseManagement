using CourseManagement.Application.Validation;
using FluentValidation;

namespace CourseManagement.Application.Course.Commands.UpdateCourse
{
    public sealed class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(CustomValidation.CheckWhiteSpace)
                .WithMessage("Can't contain whitespaces.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 50);

            RuleFor(x => x.MaxCapacity)
                .NotEqual(0);

            RuleFor(x => x.Description)
                .MinimumLength(3)
                .MaximumLength(250);
        }
    }
}