using AutoMapper;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfoByCriteria
{
    public class GetUserInfoByCriteriaHandler(IJmDbContext dbContext, IMapper mapper) : IRequestHandler<GetUserInfoByCriteriaQuery, PagedResponse<UserInfoDto>>
    {
        public async Task<PagedResponse<UserInfoDto>> Handle(GetUserInfoByCriteriaQuery request, CancellationToken cancellationToken)
        {
            var query = dbContext.PersonalInfo.AsQueryable();

            if (!string.IsNullOrEmpty(request.Name))
                query.Where(user => user.Name.StartsWith(request.Name.Trim()));

            if (!string.IsNullOrEmpty(request.LastName))
                query.Where(user => user.LastName.StartsWith(request.LastName.Trim()));

            if (!string.IsNullOrEmpty(request.Document))
                query.Where(user=> user.Document.StartsWith(request.Document.Trim()));

            var totalCount = await query.CountAsync(cancellationToken);

            var results = await query.OrderBy(user => user.LastName)
                .Skip(request.Page * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var dtos = mapper.Map<IList<UserInfoDto>>(results);

            return new PagedResponse<UserInfoDto>
            {
                Page = request.Page,
                Results = dtos,
                Total = totalCount
            };
            
        }
    }
}
