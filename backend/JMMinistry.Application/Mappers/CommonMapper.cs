using SurrealDb.Net.Models;
using Riok.Mapperly.Abstractions;

namespace JMMinistry.Application.Mappers
{
    [Mapper]
    public static partial class CommonMapper
    {
        public static string? MapRecordIdToString(RecordId? id) => id?.DeserializeId<string>();

        public static DateOnly MapDateTimeToDateOnly(DateTime dateTime) => DateOnly.FromDateTime(dateTime);

        public static DateTime MapDateOnlyToDateTime(DateOnly date) => date.ToDateTime(TimeOnly.MinValue);
        public static DateTime MapNullableDateOnlyToDateTime(DateOnly? date) => date?.ToDateTime(TimeOnly.MinValue) ?? default;
    }
}
