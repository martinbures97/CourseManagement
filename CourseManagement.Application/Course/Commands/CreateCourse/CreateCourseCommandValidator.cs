using FluentValidation;

namespace CourseManagement.Application.Course.Commands.CreateCourse
{
    public sealed class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
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