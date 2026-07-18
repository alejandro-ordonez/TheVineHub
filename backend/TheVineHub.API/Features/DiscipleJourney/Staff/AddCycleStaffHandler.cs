using TheVineHub.API.Features.DiscipleJourney;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Sessions;
using TheVineHub.API.Features.DiscipleJourney.Staff;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Attendance;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using Mediator;
using SurrealDb.Net;
using System.Linq;
using SurrealDb.Net.Models;
using SurrealDb.Net.Models.Response;

namespace TheVineHub.API.Features.DiscipleJourney.Staff
{
    public class AddCycleStaffHandler(ISurrealDbSession session)
        : ICommandHandler<AddCycleStaffCommand, CycleStaffDto>
    {
        public async ValueTask<CycleStaffDto> Handle(AddCycleStaffCommand request, CancellationToken cancellationToken)
        {
            var cycleId = ParseRecordId("cycle", request.CycleId);
            var personId = ParseRecordId("user", request.PersonId);

            var result = await session.Query(@$"
                {{
                    LET $relation = (RELATE {personId}->guides->{cycleId}
                    SET role = {request.Role.ToString()})[0];

                    LET $user = (SELECT name, last_name FROM {personId})[0];

                    RETURN {{
                        id: type::string($relation.id),
                        step_cycle_id: type::string({cycleId}),
                        person_id: type::string({personId}),
                        person_name: $user.name + ' ' + $user.last_name,
                        role: $relation.role
                    }};
                }}
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

                throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {error}");
            }

            return result.GetValue<CycleStaffDto>(0) ?? throw new Exception("Unexpected null from DB");
        }

        private static RecordId ParseRecordId(string table, string val)
        {
            var parts = val.Split(':', 2);
            return parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From(table, val);
        }
    }
}
