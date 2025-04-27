using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Queries.GetCellAttendances
{
    public class GetCellAttendancesHandler(IJmDbContext dbContext, IMediator mediator, IMapper mapper) : IRequestHandler<GetCellAttendancesQuery, IList<CellAttendanceDto>>
    {
        public async Task<IList<CellAttendanceDto>> Handle(GetCellAttendancesQuery request, CancellationToken cancellationToken)
        {
            var checkAuthorizedCommand = new CellCheckIsAuthorizedQuery { CellId = request.CellId, RequestorId = request.RequestorId };

            var isAuthorized = await mediator.Send(checkAuthorizedCommand, cancellationToken);

            if (!isAuthorized)
                throw new NotAuthorizedException();

            var attendances = await dbContext.CellAttendances
                .Include(cellAttendance => cellAttendance.Attendees)
                .Where(cellAttendance => cellAttendance.CellId == request.CellId)
                .OrderBy(cellAttendance => cellAttendance.Date)
                .Take(40)
                .ToListAsync(cancellationToken);

            return mapper.Map<IList<CellAttendanceDto>>(attendances);
        }
    }
}
