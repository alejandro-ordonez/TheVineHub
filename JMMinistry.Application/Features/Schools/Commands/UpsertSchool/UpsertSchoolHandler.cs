using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.School;
using JMMinistry.Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Schools.Commands.CreateSchool
{
    public class UpsertSchoolHandler(IJmDbContext dbContext, AppMapper mapper) : ICommandHandler<UpsertSchoolCommand, SchoolDto>
    {
        public async ValueTask<SchoolDto> Handle(UpsertSchoolCommand request, CancellationToken cancellationToken)
        {
            School school = mapper.SchoolDtoToSchool(request);

            if (request.Id == default)
            {
                dbContext.Schools.Add(school);
                await dbContext.SaveChangesAsync(cancellationToken);
            }

            else
            {
                var found = await dbContext.Schools.AnyAsync(school => school.Id == request.Id, cancellationToken);

                if (!found)
                {
                    throw new NotFoundException(school.Id.ToString());
                }

                dbContext.Schools.Update(school);
                await dbContext.SaveChangesAsync(cancellationToken);

            }
            var schoolDto = mapper.SchoolToSchoolDto(school);
            return schoolDto;
        }
    }
}
