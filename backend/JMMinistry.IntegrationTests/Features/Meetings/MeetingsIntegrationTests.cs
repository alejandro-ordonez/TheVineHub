using JMMinistry.Application.Features.Meetings.Commands.CreateMeeting;
using JMMinistry.Application.Features.Meetings.Queries.GetMeetings;
using JMMinistry.Application.Features.Meetings.Enums;
using Xunit;
using FluentAssertions;

namespace JMMinistry.IntegrationTests.Features.Meetings;

public class MeetingsIntegrationTests : BaseIntegrationTest
{
    [Fact]
    public async Task CreateAndGetMeetings_ShouldSuccessfullyManageMeetings()
    {
        // 1. Create a meeting
        var createCommand = new CreateMeetingCommand
        {
            Name = "Sunday Celebration",
            Start = "10:00:00",
            End = "12:00:00",
            MeetingType = MeetingTypes.WeAreOne,
            IsRecurrent = true,
            DayOfWeek = DayOfWeek.Sunday,
            Date = DateOnly.FromDateTime(DateTime.Today)
        };

        var created = await Mediator.Send(createCommand);

        // Assert creation
        created.Should().NotBeNull();
        created.MeetingId.Should().StartWith("church_meeting:");
        created.Name.Should().Be("Sunday Celebration");
        created.MeetingType.Should().Be(MeetingTypes.WeAreOne);
        created.IsRecurrent.Should().BeTrue();
        created.DayOfWeek.Should().Be(DayOfWeek.Sunday);
        created.Start.Should().Be("10:00:00");
        created.End.Should().Be("12:00:00");

        // 2. Query meetings
        var meetings = await Mediator.Send(new GetMeetingsQuery());

        // Assert retrieval
        meetings.Should().NotBeNull();
        meetings.Should().NotBeEmpty();

        var retrieved = meetings.FirstOrDefault(m => m.MeetingId == created.MeetingId);
        retrieved.Should().NotBeNull();
        retrieved!.Name.Should().Be("Sunday Celebration");
        retrieved.MeetingType.Should().Be(MeetingTypes.WeAreOne);
    }
}
