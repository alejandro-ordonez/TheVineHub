using System;
using System.Collections.Generic;
using System.Text;

namespace JMMinistry.Common.Dtos.User
{
    public class DiscipleDto : BasicUserInfoDto
    {
        public DateTime MemberSince { get; set; }
        public string? CellId { get; set; }
        public string? DiscipleStep { get; set; }
    }
}
