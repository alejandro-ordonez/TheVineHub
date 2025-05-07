using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.User;
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

            var cell = await dbContext.Cells
                .Include(cell => cell.Disciples)
                .FirstOrDefaultAsync(cell => cell.Id == request.CellId, cancellationToken);

            var disciples = cell?.Disciples ?? [];

            var attendancesDto = new List<CellAttendanceDto>();

            foreach (var attendance in attendances)
            {
                var missingAttendees = disciples
                    .Where(disciple => disciple.CellEnrollmentDate < attendance.Date)
                    .Except(attendance.Attendees);

                var dto = mapper.Map<CellAttendanceDto>(attendance);
                dto.MissingAttendees = mapper.Map<IList<PartialUserInfoDto>>(missingAttendees);
                attendancesDto.Add(dto);
            }

            return attendancesDto;
        }
    }
}
