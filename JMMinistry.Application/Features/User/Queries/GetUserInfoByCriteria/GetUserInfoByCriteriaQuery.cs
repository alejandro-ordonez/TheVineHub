using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using MediatR;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfoByCriteria
{
    public class GetUserInfoByCriteriaQuery : UsersSearchCriteria, IRequest<PagedResponse<PartialUserInfoDto>>
    {
    }
}
