using JMMinistry.Application.Features.User;
using JMMinistry.Application.Mappers;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Domain.Cells;
using Riok.Mapperly.Abstractions;
using SurrealDb.Net.Models;

namespace JMMinistry.Application.Features.Cells
{
    [Mapper]
    [UseStaticMapper(typeof(CommonMapper))]
    [UseStaticMapper(typeof(UserMapper))]
    public static partial class CellMapper
    {
        public static partial CellDto ToDto(this Cell source);

        [MapperIgnoreSource(nameof(CellDto.Level))]
        [MapperIgnoreTarget(nameof(Cell.Level))]
        [MapperIgnoreSource(nameof(CellDto.Leaders))]
        [MapperIgnoreTarget(nameof(Cell.Leaders))]
        [MapperIgnoreSource(nameof(CellDto.MemberCount))]
        [MapperIgnoreTarget(nameof(Cell.MemberCount))]
        public static partial Cell ToEntity(this CellDto source);

        public static partial IEnumerable<CellDto> ToDto(this IEnumerable<Cell> source);
        public static partial IQueryable<CellDto> ProjectToDto(this IQueryable<Cell> source);

        private static RecordId? MapId(string? id) => id != null ? new RecordIdOfString("cell", id) : null;

        private static DayOfWeek? MapDay(string day)
        {
            if (Enum.TryParse<DayOfWeek>(day, true, out var result))
            {
                return result;
            }
            return null;
        }
        private static string MapDay(DayOfWeek? day) => day?.ToString() ?? string.Empty;
    }
}