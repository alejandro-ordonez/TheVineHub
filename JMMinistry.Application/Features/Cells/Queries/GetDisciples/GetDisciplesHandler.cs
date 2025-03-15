using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.User.Queries.CheckIfLeader;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Domain;
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

            if(cell.Disciples.Any(disciple => disciple.Id == request.RequestorId))
                return mapper.Map<IEnumerable<PartialUserInfoDto>>(cell.Disciples);

            if (request.RequestorId is null)
                throw new ArgumentException("No leader Id provided");

            var checkIfLeader = new CheckIfLeaderQuery
            {
                CellId = request.CellId,
                LeaderId = request.RequestorId
            };

            var isLeader = await mediator.Send(checkIfLeader, cancellationToken);

            if (!isLeader)
                throw new NotAuthorizeException();

            return mapper.Map<IEnumerable<PartialUserInfoDto>>(cell.Disciples);
        }
    }
}
