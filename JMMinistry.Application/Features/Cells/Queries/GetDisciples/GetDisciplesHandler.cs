using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.User;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Queries.GetDisciples
{
    public class GetDisciplesHandler
        (
            IJmDbContext dbContext,
            AppMapper mapper,
            IMediator mediator
        )
        : IQueryHandler<GetDisciplesQuery, IEnumerable<PartialUserInfoDto>>
    {
        public async ValueTask<IEnumerable<PartialUserInfoDto>> Handle(GetDisciplesQuery request, CancellationToken cancellationToken)
        {
            var cell = await dbContext.Cells
                .Include(cell => cell.Disciples)
                .FirstOrDefaultAsync(cell => cell.Id == request.CellId, cancellationToken) ??
                    throw new NotFoundException("The requested cell does not exists");

            if (cell.Disciples.Any(disciple => disciple.Id == request.RequestorId))
                return mapper.PersonalInfoCollectionToPartialUserInfoDtoList(cell.Disciples);

            var checkIfLeader = new CellCheckIsAuthorizedQuery
            {
                CellId = request.CellId,
                RequestorId = request.RequestorId
            };

            var isLeader = await mediator.Send(checkIfLeader, cancellationToken);

            if (!isLeader)
                throw new NotAuthorizedException();

            return mapper.PersonalInfoCollectionToPartialUserInfoDtoList(cell.Disciples);
        }
    }
}
