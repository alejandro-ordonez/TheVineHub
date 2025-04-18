using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Queries.GetDisciples
{
    public class GetDisciplesHandler 
        (
            IJmDbContext dbContext,
            IMapper mapper,
            IMediator mediator
        )
        : IRequestHandler<GetDisciplesQuery, IEnumerable<PartialUserInfoDto>>
    {
        public async Task<IEnumerable<PartialUserInfoDto>> Handle(GetDisciplesQuery request, CancellationToken cancellationToken)
        {
            var cell = await dbContext.Cells
                .Include(cell => cell.Disciples)
                .FirstOrDefaultAsync(cell =>  cell.Id == request.CellId, cancellationToken) ?? 
                    throw new NotFoundException("The requested cell does not exists");            

            if (cell.Disciples.Any(disciple => disciple.Id == request.RequestorId))
                return mapper.Map<IEnumerable<PartialUserInfoDto>>(cell.Disciples);

            var checkIfLeader = new CellCheckIsAuthorizedQuery
            {
                CellId = request.CellId,
                RequestorId = request.RequestorId
            };

            var isLeader = await mediator.Send(checkIfLeader, cancellationToken);

            if (!isLeader)
                throw new NotAuthorizedException();

            return mapper.Map<IEnumerable<PartialUserInfoDto>>(cell.Disciples);
        }
    }
}
