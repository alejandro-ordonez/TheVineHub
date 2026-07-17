using Mediator;
using TheVineHub.API.Features.Meetings;

namespace TheVineHub.API.Features.Meetings.CreateMeeting
{
    public sealed record CreateMeetingRequest(
        string Name,
        string Start,
        string End,
        MeetingTypes MeetingType,
        bool IsRecurrent,
        DayOfWeek? DayOfWeek,
        DateOnly Date
    );

    public sealed class CreateMeetingCommand : ICommand<MeetingDto>
    {
        public required string Name { get; init; }
        public string Start { get; init; } = "10:00:00";
        public string End { get; init; } = "11:00:00";
        public MeetingTypes MeetingType { get; init; }
        public bool IsRecurrent { get; init; }
        public DayOfWeek? DayOfWeek { get; init; }
        public DateOnly Date { get; init; }
    }
}
