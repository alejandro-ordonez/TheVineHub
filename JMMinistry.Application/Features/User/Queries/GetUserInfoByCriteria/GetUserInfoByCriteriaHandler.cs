using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfoByCriteria
{
    public class GetUserInfoByCriteriaHandler(IJmDbContext dbContext, AppMapper mapper) : IQueryHandler<GetUserInfoByCriteriaQuery, PagedResponse<PartialUserInfoDto>>
    {
        public async ValueTask<PagedResponse<PartialUserInfoDto>> Handle(GetUserInfoByCriteriaQuery request, CancellationToken cancellationToken)
        {
            var query = dbContext.PersonalInfo.AsQueryable();
            query = GetQuery(query, request);

            var totalCount = await query.CountAsync(cancellationToken);

            var results = await query.OrderBy(GetOrderMember(request.OrderByMember))
                .Skip(request.Page * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var dtos = mapper.PersonalInfoListToPartialUserInfoDtoList(results);

            return new PagedResponse<PartialUserInfoDto>
            {
                Page = request.Page,
                Results = dtos,
                Total = totalCount
            };

        }

        private static IQueryable<PersonalInfo> GetQuery(IQueryable<PersonalInfo> query, GetUserInfoByCriteriaQuery request)
        {
            var newQuery = query;

            if (!string.IsNullOrEmpty(request.Name))
                newQuery = newQuery.Where(user => user.Name.StartsWith(request.Name.Trim()));

            if (!string.IsNullOrEmpty(request.LastName))
                newQuery = newQuery.Where(user => user.LastName.StartsWith(request.LastName.Trim()));

            if (!string.IsNullOrEmpty(request.Document))
                newQuery = newQuery.Where(user => user.Id.StartsWith(request.Document.Trim()));

            return newQuery;
        }


        private static Expression<Func<PersonalInfo, object?>> GetOrderMember(string? orderBy) => orderBy switch
        {
            "Document" => info => info.Id,
            "Name" => info => info.Name,
            _ => info => info.Name
        };
    }
}
