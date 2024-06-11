using JMMinistry.Common.Dtos.School;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.School.Queries.GetSchoolById
{
    public class GetSchoolByIdCommand: IRequest<SchoolWithClassesDto>
    {
        public int SchoolId { get; set; }
    }
}
