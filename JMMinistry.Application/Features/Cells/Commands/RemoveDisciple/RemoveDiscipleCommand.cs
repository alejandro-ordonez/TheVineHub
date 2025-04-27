using FluentValidation;
using JMMinistry.Common.Dtos.User;
using MediatR;

namespace JMMinistry.Application.Features.Cells.Commands.RemoveDisciple
{
    public class RemoveDiscipleCommand : IRequest<IList<PartialUserInfoDto>>
    {
        public required int CellId { get; set; }
        public required string Document { get; set; }
    }

    public class RemoveDiscipleValidator : AbstractValidator<RemoveDiscipleCommand>
    {
        public RemoveDiscipleValidator()
        {
            RuleFor(x => x.CellId)
                .GreaterThan(0);

            RuleFor(x => x.Document)
                .NotEmpty();
        }
    }
}
