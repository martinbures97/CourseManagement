using CourseManagement.Application.Validation;
using FluentValidation;

namespace CourseManagement.Application.Teacher.Commands.UpdateTeacher
{
    public sealed class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
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