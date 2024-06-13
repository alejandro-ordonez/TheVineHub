using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.School;
using JMMinistry.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Schools.Commands.CreateSchool
{
    public class UpsertSchoolHandler(IJmDbContext dbContext, IMapper mapper) : IRequestHandler<UpsertSchoolCommand, SchoolDto>
    {
        public async Task<SchoolDto> Handle(UpsertSchoolCommand request, CancellationToken cancellationToken)
        {
            School school = mapper.Map<School>(request);

            if(request.Id == default)
            {                
                dbContext.Schools.Add(school);
                await dbContext.SaveChangesAsync(cancellationToken);
            }

            else
            {
                var found = await dbContext.Schools.AnyAsync(school => school.Id == request.Id, cancellationToken);

                if(!found)
                {
                    throw new NotFoundException(school.Id.ToString());
                }

                dbContext.Schools.Update(school);
                await dbContext.SaveChangesAsync(cancellationToken);

            }
            var schoolDto = mapper.Map<SchoolDto>(school);
            return schoolDto;
        }
    }
}
