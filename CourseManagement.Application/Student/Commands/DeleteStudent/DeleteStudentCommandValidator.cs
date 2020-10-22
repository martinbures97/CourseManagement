using CourseManagement.Application.Validation;
using FluentValidation;

namespace CourseManagement.Application.Student.Commands.DeleteStudent
{
    public sealed class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(CustomValidation.CheckWhiteSpace)
                .WithMessage("Can't contain whitespaces.");
        }
    }
}