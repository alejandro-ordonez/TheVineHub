using JMMinistry.Application.Features.Location.Dtos;
using JMMinistry.Application.Common;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;
using Mediator;
using SurrealDb.Net;
using System.Text;

using System.Linq;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfoByCriteria
{
    public class GetUserInfoByCriteriaHandler(ISurrealDbSession session) 
        : IQueryHandler<GetUserInfoByCriteriaQuery, PagedResponse<BasicUserInfoDto>>
    {
        public async ValueTask<PagedResponse<BasicUserInfoDto>> Handle(GetUserInfoByCriteriaQuery request, CancellationToken cancellationToken)
        {
            var filters = new List<string>();

            if (!string.IsNullOrEmpty(request.Name))
            {
                filters.Add($"name ~ '{request.Name.Trim()}'");
            }

            if (!string.IsNullOrEmpty(request.LastName))
            {
                filters.Add($"last_name ~ '{request.LastName.Trim()}'");
            }

            if (!string.IsNullOrEmpty(request.Document))
            {
                filters.Add($"id ~ 'user:{request.Document.Trim()}'");
            }

            var whereClause = filters.Any() ? " WHERE " + string.Join(" AND ", filters) : "";

            var orderBy = request.OrderByMember switch
            {
                "Document" => "id",
                "Name" => "name",
                _ => "name"
            };

            var direction = request.OrderDirection?.ToUpper() == "DESC" ? "DESC" : "ASC";
            var start = (request.Page - 1) * request.PageSize;

            var result = await session.Query(@$"
                SELECT * FROM user {whereClause} ORDER BY {orderBy} {direction} LIMIT {request.PageSize} START {start};
                SELECT count() FROM user {whereClause};
            ", cancellationToken);

            var users = result.GetValue<List<BasicUserInfoDto>>(0);
            var total = result.GetValue<List<dynamic>>(1)?.FirstOrDefault()?.count ?? 0;

            return new PagedResponse<BasicUserInfoDto>
            {
                Page = request.Page,
                Results = users ?? [],
                Total = (int)total
            };
        }
    }
}
