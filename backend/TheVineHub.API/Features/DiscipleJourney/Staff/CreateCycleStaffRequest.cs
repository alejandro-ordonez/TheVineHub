using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.DiscipleJourney;

namespace TheVineHub.API.Features.DiscipleJourney.Staff
{
    public class CreateCycleStaffRequest
    {
        public required string PersonId { get; set; }
        public CycleStaffRole Role { get; set; }
    }
}
