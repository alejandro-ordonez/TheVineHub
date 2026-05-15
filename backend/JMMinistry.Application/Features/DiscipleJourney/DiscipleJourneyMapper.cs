using JMMinistry.Application.Mappers;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Domain.DiscipleJourney;
using Riok.Mapperly.Abstractions;
using SurrealDb.Net.Models;

namespace JMMinistry.Application.Features.DiscipleJourney
{
    [Mapper]
    [UseStaticMapper(typeof(CommonMapper))]
    public static partial class DiscipleJourneyMapper
    {
        [MapProperty(nameof(BaseDiscipleStep.ParentStepId), nameof(DiscipleStepDto.ParentId))]
        public static partial DiscipleStepDto ToDto(this DiscipleStep source);

        [MapProperty(nameof(BaseDiscipleStep.ParentStepId), nameof(DiscipleStepDto.ParentId))]
        public static partial DiscipleStepDto ToDto(this BaseDiscipleStep source);

        public static partial IEnumerable<DiscipleStepDto> ToDto(this IEnumerable<DiscipleStep> source);

        private static string MapRecordIdToString(RecordId id) => id.DeserializeId<string>();

        private static IList<string> MapRequirementIds(List<RecordId> source)
            => source.Select(id => id.DeserializeId<string>()).ToList();

        private static IList<DiscipleStepDto> MapSubSteps(IList<BaseDiscipleStep>? source)
            => source?.Select(ToDto).ToList() ?? [];
    }
}
