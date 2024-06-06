using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.School.Commands.CreateSchool
{
    public class CreateSchoolValidator: AbstractValidator<CreateSchoolCommand>
    {
        public CreateSchoolValidator()
        {
            RuleFor(school => school.SchoolName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name of the school can't be empty");

            RuleFor(school => school.SchoolDescription)
                .NotEmpty()
                .NotNull()
                .WithMessage("Description of the school can't be empty");
        }
    }
}
