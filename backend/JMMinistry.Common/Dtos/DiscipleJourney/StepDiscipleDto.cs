using JMMinistry.Common.Dtos.DiscipleJourney.Enums;
using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class StepDiscipleDto : BasicUserInfoDto
    {
        public StepStatus? StepStatus { get; set; }
        public DateOnly LastUpdated { get; set; }
        public CycleEnrollmentSummaryDto? CycleEnrollmentSummary { get; set; }
    }
}
