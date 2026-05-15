using FluentValidation;
using JMMinistry.Common.Dtos.User;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Commands.RemoveDisciple
{
    public class RemoveDiscipleCommand : ICommand<IList<DiscipleDto>>
    {
        public required string CellId { get; set; }
        public required string Document { get; set; }
    }

    public class RemoveDiscipleValidator : AbstractValidator<RemoveDiscipleCommand>
    {
        public RemoveDiscipleValidator()
        {
            RuleFor(x => x.CellId)
                .NotEmpty();

            RuleFor(x => x.Document)
                .NotEmpty();
        }
    }
}
