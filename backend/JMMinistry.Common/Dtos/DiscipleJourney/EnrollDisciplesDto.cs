using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class EnrollDisciplesDto
    {
        public IList<string> DiscipleIds { get; set; } = [];
        public StepStatus? InitialStatus { get; set; }
    }
}
