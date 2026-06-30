using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle;
using JMMinistry.Application.Features.DiscipleJourney.Enums;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCycle
{
    public class UpdateStepCycleDto : CreateStepCycleDto
    {
        [Column("is_open")]
        public bool IsOpen { get; set; }
    }
}
