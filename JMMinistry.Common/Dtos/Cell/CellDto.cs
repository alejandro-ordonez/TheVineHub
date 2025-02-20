using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.Cell
{
    public class CellDto: CreateCellDto
    {
        public IList<UserInfoDto> Disciples { get; set; } = [];
    }

}
