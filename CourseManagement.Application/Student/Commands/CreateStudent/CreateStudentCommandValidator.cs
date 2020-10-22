using FluentValidation;

namespace CourseManagement.Application.Student.Commands.CreateStudent
{
    public sealed class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 50);
        }
    }
}