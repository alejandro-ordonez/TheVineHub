using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TheVineHub.API.Configuration;

namespace TheVineHub.API.Features.Meetings.CreateMeeting
{
    public class CreateMeetingEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/meetings", async ([FromBody] CreateMeetingRequest request, IMediator mediator, IOutputCacheStore cache) =>
            {
                var command = new CreateMeetingCommand
                {
                    Name = request.Name,
                    Start = request.Start,
                    End = request.End,
                    MeetingType = request.MeetingType,
                    IsRecurrent = request.IsRecurrent,
                    DayOfWeek = request.DayOfWeek,
                    Date = request.Date
                };

                var result = await mediator.Send(command);
                await cache.EvictByTagAsync(CacheTags.Meetings, default);
                return Results.Ok(result);
            })
            .WithName("CreateMeeting")
            .WithTags("Meetings")
            .RequireAuthorization();
        }
    }
}
