using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.Gained
{
    public class GainedUser: CreateGainedUser
    {
        public List<GainedEvent> Events { get; set; }
    }
}
