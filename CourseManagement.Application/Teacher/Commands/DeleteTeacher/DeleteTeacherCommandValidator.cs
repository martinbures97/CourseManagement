using CourseManagement.Application.Validation;
using FluentValidation;

namespace CourseManagement.Application.Teacher.Commands.DeleteTeacher
{
    public sealed class DeleteTeacherCommandValidator : AbstractValidator<DeleteTeacherCommand>
    {
        public DeleteTeacherCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(CustomValidation.CheckWhiteSpace)
                .WithMessage("Can't contain whitespaces.");
        }
    }
}