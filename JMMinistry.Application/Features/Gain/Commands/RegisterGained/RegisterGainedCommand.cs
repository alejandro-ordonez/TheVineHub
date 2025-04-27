using JMMinistry.Common.Dtos.Gained;
using JMMinistry.Common.Dtos.User;
using MediatR;

namespace JMMinistry.Application.Features.Gain.Commands.RegisterGained
{
    public class RegisterGainedCommand : IRequest<PartialUserInfoDto>
    {
        public string? GainedBy { get; set; }
        public required CreateGainedUser GainedInfo { get; set; }
    }
}
