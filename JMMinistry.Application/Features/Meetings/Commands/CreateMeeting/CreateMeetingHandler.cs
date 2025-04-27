using AutoMapper;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Meetings;
using JMMinistry.Domain;
using MediatR;

namespace JMMinistry.Application.Features.Meetings.Commands.CreateMeeting
{
    public class CreateMeetingHandler(IJmDbContext dbContext, IMapper mapper) : IRequestHandler<CreateMeetingCommand, MeetingDto>
    {
        public async Task<MeetingDto> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<Meeting>(request);

            dbContext.Meetings.Add(model);
            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<MeetingDto>(model);
        }
    }
}
