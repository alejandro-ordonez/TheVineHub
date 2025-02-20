using JMMinistry.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.Cell
{
    public class CreateCellDto: CardModel<int>
    {
        public bool MainCell { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
