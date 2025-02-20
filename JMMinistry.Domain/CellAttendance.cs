using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Domain
{
    public class CellAttendance
    {
        public int Id { get; set; }
        [Required]
        public int CellId { get; set; }
        public Cell Cell { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        public IList<PersonalInfo> Attendees { get; set; } = Array.Empty<PersonalInfo>();

    }
}
