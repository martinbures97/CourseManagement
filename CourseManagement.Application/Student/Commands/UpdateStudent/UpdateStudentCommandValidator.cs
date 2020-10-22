using CourseManagement.Application.Validation;
using FluentValidation;

namespace CourseManagement.Application.Student.Commands.UpdateStudent
{
    public sealed class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(CustomValidation.CheckWhiteSpace)
                .WithMessage("Can't contain whitespaces.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 50);
        }
    }
}