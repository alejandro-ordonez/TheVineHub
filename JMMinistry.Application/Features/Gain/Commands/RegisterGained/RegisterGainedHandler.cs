using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Gained;
using JMMinistry.Common.Dtos.Gained.Enums;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Gain.Commands.RegisterGained
{
    public class RegisterGainedHandler(IJmDbContext dbContext, AppMapper mapper) : ICommandHandler<RegisterGainedCommand, PartialUserInfoDto>
    {
        public async ValueTask<PartialUserInfoDto> Handle(RegisterGainedCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.CreateGainedUserToPersonalInfo(request.GainedInfo);

            if (await dbContext.PersonalInfo.AnyAsync(person => person.Id == request.GainedInfo.Document, cancellationToken))
                throw new EntityAlreadyExistsException<PersonalInfo>(request.GainedInfo.Document);

            var registeredEvent = new Domain.GainedEvent
            {
                EventType = GainedEventType.Registration,
                Date = DateOnly.FromDateTime(DateTime.Today),
                Observations = request.GainedInfo.Petition
            };

            var gained = new Gained
            {
                Date = DateOnly.FromDateTime(DateTime.Today),
                PersonId = model.Id,
                Person = model,
                InvitedById = request.GainedBy,
                Events = [registeredEvent]
            };

            dbContext.Gained.Add(gained);

            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.GainedToGainedUser(gained);
        }
    }
}
