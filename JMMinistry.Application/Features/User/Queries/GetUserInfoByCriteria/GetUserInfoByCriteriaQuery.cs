using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using Mediator;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfoByCriteria
{
    public class GetUserInfoByCriteriaQuery : UsersSearchCriteria, IQuery<PagedResponse<PartialUserInfoDto>>
    {
    }
}
