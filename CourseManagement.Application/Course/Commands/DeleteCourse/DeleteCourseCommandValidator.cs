using CourseManagement.Application.Validation;
using FluentValidation;

namespace CourseManagement.Application.Course.Commands.DeleteCourse
{
    public sealed class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(CustomValidation.CheckWhiteSpace)
                .WithMessage("Can't contain whitespaces.");
        }
    }
}