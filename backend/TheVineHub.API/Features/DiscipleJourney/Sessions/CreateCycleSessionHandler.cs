using TheVineHub.API.Configuration.Exceptions;
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

namespace TheVineHub.API.Features.DiscipleJourney.Sessions
{
    public class CreateCycleSessionHandler(ISurrealDbSession session)
        : ICommandHandler<CreateCycleSessionCommand, CycleSessionDto>
    {
        public async ValueTask<CycleSessionDto> Handle(CreateCycleSessionCommand request, CancellationToken cancellationToken)
        {
            var cycleRecordId = ParseRecordId("cycle", request.CycleId);

            var result = await session.Query(@$"
                LET $cs_session = (CREATE cycle_session SET
                    date = {request.Date.ToDateTime(TimeOnly.MinValue)},
                    topic = {request.Topic},
                    cycle = {cycleRecordId})[0];

                RETURN {{
                    id: type::string($cs_session.id),
                    step_cycle_id: type::string({cycleRecordId}),
                    date: $cs_session.date,
                    topic: $cs_session.topic
                }};
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

                throw new DatabaseExecutionException($"SurrealDB Error: {error}");
            }

            return result.GetValue<CycleSessionDto>(1) ?? throw new Exception("Unexpected null from DB");
        }

        private static RecordId ParseRecordId(string table, string val)
        {
            var parts = val.Split(':', 2);
            return parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From(table, val);
        }
    }
}
