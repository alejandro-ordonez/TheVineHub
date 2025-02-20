using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.User
{
    public class UserCriteriaSearch: PagedRequest
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Document { get; set; }
        public bool? IsLeader { get; set; }
        public MinistryStatus? MinistryStatus { get; set; }
        public MemberType? MemberType { get; set; }

    }
}
