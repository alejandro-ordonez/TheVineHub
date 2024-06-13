using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Schools.Commands.CreateSchool
{
    public class UpsertSchoolValidator: AbstractValidator<UpsertSchoolCommand>
    {
        public UpsertSchoolValidator()
        {
            RuleFor(school => school.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name of the school can't be empty");

            RuleFor(school => school.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Description of the school can't be empty");
        }
    }
}
