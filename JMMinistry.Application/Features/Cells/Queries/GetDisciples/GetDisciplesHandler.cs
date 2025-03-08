using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Queries.GetDisciples
{
    public class GetDisciplesHandler 
        (
            IJmDbContext dbContext,
            IMapper mapper
        )
        : IRequestHandler<GetDisciplesQuery, PagedResponse<UserInfoDto>>
    {
        public async Task<PagedResponse<UserInfoDto>> Handle(GetDisciplesQuery request, CancellationToken cancellationToken)
        {
            var cell = await dbContext.Cells
                .Include(cell => cell.Leaders)
                .Include(cell => cell.Disciples)
                .FirstOrDefaultAsync(cell =>
                    cell.Id == request.CellId &&
                    cell.Leaders.Any(leader => leader.Id == request.DocumentLeader), cancellationToken
                    ) ?? throw new NotFoundException("The requested cell is not accessible to this user, or it does not exists");

            var disciples = cell.Disciples
                .Skip(request.Page * request.PageSize)
                .Take(request.PageSize);

            var response = new PagedResponse<UserInfoDto>
            {
                Page = request.Page,
                Total = cell.Disciples.Count,
                Results = mapper.Map<IList<UserInfoDto>>(disciples)
            };

            return response;
        }
    }
}
