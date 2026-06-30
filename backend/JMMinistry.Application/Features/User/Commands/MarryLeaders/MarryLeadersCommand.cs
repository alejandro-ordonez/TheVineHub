using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.MarryLeaders;

public class MarryLeadersCommand : ICommand
{
    [Column("requestor_id")]
    public required string RequestorId { get; set; }
    [Column("person_id")]
    public required string PersonId { get; set; }
    [Column("spouse_id")]
    public required string SpouseId { get; set; }
}

public class MarryLeadersValidator : AbstractValidator<MarryLeadersCommand>
{
    public MarryLeadersValidator()
    {
        RuleFor(x => x.RequestorId).NotEmpty();
        RuleFor(x => x.PersonId).NotEmpty();
        RuleFor(x => x.SpouseId).NotEmpty();
        RuleFor(x => x.PersonId).NotEqual(x => x.SpouseId);
    }
}
