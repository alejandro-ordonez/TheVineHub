using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.School;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Schools.Queries.GetSchools
{
    public class GetSchoolsHandler(IJmDbContext dbContext, AppMapper mapper) : IQueryHandler<GetSchoolsCommand, IEnumerable<SchoolDto>>
    {
        public async ValueTask<IEnumerable<SchoolDto>> Handle(GetSchoolsCommand request, CancellationToken cancellationToken)
        {
            var schools = await dbContext.Schools.ToListAsync(cancellationToken);
            var schoolsDto = mapper.SchoolListToSchoolDtoList(schools);

            return schoolsDto;
        }
    }
}
