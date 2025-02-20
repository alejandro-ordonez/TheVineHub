using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.Cell
{
    public class AddDisciplesDto
    {
        public int CellId { get; set; }
        public IList<string> Documents { get; set; } = [];
    }
}
