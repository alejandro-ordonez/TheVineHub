using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Meetings;
using JMMinistry.Domain;
using Mediator;

namespace JMMinistry.Application.Features.Meetings.Commands.CreateMeeting
{
    public class CreateMeetingHandler(IJmDbContext dbContext, AppMapper mapper) : ICommandHandler<CreateMeetingCommand, MeetingDto>
    {
        public async ValueTask<MeetingDto> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.CreateMeetingDtoToMeeting(request);

            dbContext.Meetings.Add(model);
            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.MeetingToMeetingDto(model);
        }
    }
}
