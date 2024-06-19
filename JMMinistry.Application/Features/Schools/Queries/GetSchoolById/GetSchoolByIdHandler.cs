using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.School;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Schools.Queries.GetSchoolById
{
    public class GetSchoolByIdHandler(IJmDbContext dbContext, IMapper mapper) : IRequestHandler<GetSchoolByIdCommand, SchoolWithClassesDto>
    {
        public async Task<SchoolWithClassesDto> Handle(GetSchoolByIdCommand request, CancellationToken cancellationToken)
        {
            var school = await dbContext.Schools
                .Include(school => school.Classes)
                .FirstOrDefaultAsync(school => school.Id == request.SchoolId, cancellationToken) ?? throw new NotFoundException(request.SchoolId.ToString());

            var schoolDto = mapper.Map<SchoolWithClassesDto>(school);
            
            return schoolDto;
        }
    }
}
