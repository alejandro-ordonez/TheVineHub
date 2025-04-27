using JMMinistry.Common.Models;

namespace JMMinistry.Common.Dtos.Class
{
    public class ClassDto : CardModel
    {
        public DateOnly StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
