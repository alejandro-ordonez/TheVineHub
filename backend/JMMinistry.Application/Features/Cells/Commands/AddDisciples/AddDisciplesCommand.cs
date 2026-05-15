using FluentValidation;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.User;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Commands.AddDisciples
{
    public class AddDisciplesCommand : AddDisciplesDto, ICommand<List<DiscipleDto>>
    {
    }

    public class AddDisciplesValidator : AbstractValidator<AddDisciplesCommand>
    {
        public AddDisciplesValidator()
        {
            RuleFor(x => x.CellId)
                .NotEmpty();

            RuleFor(x => x.Documents)
                .NotEmpty();
        }
    }
}
