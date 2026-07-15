using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.DiscipleJourney;
using TheVineHub.API.Features.Users;
using TheVineHub.API.Features.Users.Authenticate;
using TheVineHub.API.Features.Users.CreateUser;
using TheVineHub.API.Features.Users.MarryLeaders;

namespace TheVineHub.API.Features.DiscipleJourney
{
    public class StepDiscipleDto : BasicUserInfoDto
    {
        [Column("step_status")]
        public StepStatus? StepStatus { get; set; }
        [Column("last_updated")]
        public DateOnly LastUpdated { get; set; }
        [Column("cycle_enrollment_summary")]
        public CycleEnrollmentSummaryDto? CycleEnrollmentSummary { get; set; }
    }
}
