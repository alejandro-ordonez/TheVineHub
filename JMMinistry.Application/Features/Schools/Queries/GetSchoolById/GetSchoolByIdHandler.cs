using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.School;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Schools.Queries.GetSchoolById
{
    public class GetSchoolByIdHandler(IJmDbContext dbContext, AppMapper mapper) : IQueryHandler<GetSchoolByIdCommand, SchoolWithClassesDto>
    {
        public async ValueTask<SchoolWithClassesDto> Handle(GetSchoolByIdCommand request, CancellationToken cancellationToken)
        {
            var school = await dbContext.Schools
                .Include(school => school.Classes)
                .FirstOrDefaultAsync(school => school.Id == request.SchoolId, cancellationToken) ?? throw new NotFoundException(request.SchoolId.ToString());

            var schoolDto = mapper.SchoolToSchoolWithClassesDto(school);

            return schoolDto;
        }
    }
}
