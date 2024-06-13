using JMMinistry.Common.Dtos.Class;
using JMMinistry.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace JMMinistry.Common.Dtos.School
{
    public class SchoolDto: CardModel<int>
    {
    }

    public class SchoolDtoValidator: CardModelValidator<int>
    {
        public SchoolDtoValidator(): base()
        {
        }
    }
}
