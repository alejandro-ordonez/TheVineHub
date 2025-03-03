using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.User.Enums
{
    public enum MinistryStatus
    {
        Unknown,
        Gained,
        Baptized,
        InACell,
        Timothy,
        /// <summary>
        /// People who doesn't have a 
        /// </summary>
        Sent,
        Leader,
        Admin
    }
}
