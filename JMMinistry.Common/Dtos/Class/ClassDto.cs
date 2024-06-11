using JMMinistry.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.Class
{
    public class ClassDto: CardModel<int>
    {
        public DateOnly StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
