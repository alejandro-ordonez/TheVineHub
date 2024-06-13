using JMMinistry.Common.Dtos.School;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Schools.Queries.GetSchools
{
    public class GetSchoolsCommand: IRequest<IEnumerable<SchoolDto>>
    {
    }
}
