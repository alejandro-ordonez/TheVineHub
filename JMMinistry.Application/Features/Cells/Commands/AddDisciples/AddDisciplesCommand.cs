using FluentValidation;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.User;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Commands.AddDisciples
{
    public class AddDisciplesCommand : AddDisciplesDto, ICommand<List<PartialUserInfoDto>>
    {
    }

    public class AddDisciplesValidator : AbstractValidator<AddDisciplesCommand>
    {
        public AddDisciplesValidator()
        {
            RuleFor(x => x.CellId)
                .NotEqual(0);

            RuleFor(x => x.Documents)
                .NotEmpty();
        }
    }
}
