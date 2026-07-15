using System.ComponentModel.DataAnnotations.Schema;
namespace TheVineHub.API.Features.DiscipleJourney.Sessions
{
    public class CreateCycleSessionRequest
    {
        public DateOnly Date { get; set; }
        public string? Topic { get; set; }
    }
}
