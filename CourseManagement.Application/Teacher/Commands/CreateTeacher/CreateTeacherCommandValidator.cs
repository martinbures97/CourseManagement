using FluentValidation;

namespace CourseManagement.Application.Teacher.Commands.CreateTeacher
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 50);
        }
    }
}