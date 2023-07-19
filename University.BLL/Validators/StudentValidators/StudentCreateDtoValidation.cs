using FluentValidation;
using University.BLL.Dtos;

namespace University.BLL.Validators.StudentValidators
{
    public class StudentCreateDtoValidation : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidation()
        {
            RuleFor(x => x.Firstname).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20).WithMessage("jbjh");
            RuleFor(x => x.Age).GreaterThan((byte)17).WithMessage("Yas 17-den olmalidir").LessThan((byte)60).WithMessage("Yas 60-dan kicik olmalidir");
        }
    }
}
