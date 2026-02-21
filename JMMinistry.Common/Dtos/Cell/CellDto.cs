using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Models;

namespace JMMinistry.Common.Dtos.Cell
{
    public class CellDto : CardModel
    {
        public bool MainCell { get; set; }
        public string Address { get; set; } = string.Empty;
        public CityDto? City { get; set; }
        public LocalityDto? Locality { get; set; }
        public DayOfWeek? Day { get; set; }
        public DateOnly? OpeningDate { get; set; }

    }
}
