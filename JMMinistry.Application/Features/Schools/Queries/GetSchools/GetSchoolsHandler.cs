using AutoMapper;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.School;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Schools.Queries.GetSchools
{
    public class GetSchoolsHandler(IJmDbContext dbContext, IMapper mapper) : IRequestHandler<GetSchoolsCommand, IEnumerable<SchoolDto>>
    {
        public async Task<IEnumerable<SchoolDto>> Handle(GetSchoolsCommand request, CancellationToken cancellationToken)
        {
            var schools = await dbContext.Schools.ToListAsync(cancellationToken);
            var schoolsDto = mapper.Map<IEnumerable<SchoolDto>>(schools);

            return schoolsDto;
        }
    }
}
