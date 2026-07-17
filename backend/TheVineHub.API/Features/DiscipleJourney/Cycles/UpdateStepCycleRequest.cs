using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using TheVineHub.API.Features.DiscipleJourney;

namespace TheVineHub.API.Features.DiscipleJourney.Cycles
{
    public class UpdateStepCycleRequest : CreateStepCycleRequest
    {
        public bool IsOpen { get; set; }
    }
}
