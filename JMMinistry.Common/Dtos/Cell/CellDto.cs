using JMMinistry.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.Cell
{
    public class CellDto: CardModel<int>
    {
        public bool MainCell { get; set; }
        public int Disciples { get; set; }
    }
}
