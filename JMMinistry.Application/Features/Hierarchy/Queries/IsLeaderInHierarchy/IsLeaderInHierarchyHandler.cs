using JMMinistry.Application.Services;
using Mediator;

namespace JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy
{
    public class IsLeaderInHierarchyHandler(IJmDbContext dbContext)
        : IQueryHandler<IsLeaderInHierarchyQuery, bool>
    {
        public async ValueTask<bool> Handle(IsLeaderInHierarchyQuery request, CancellationToken cancellationToken)
        {
            var result = await dbContext.ExecuteScalarFunctionAsync<bool>(
                "SELECT is_leader_in_hierarchy({0}, {1}) AS \"Value\"",
                cancellationToken,
                request.RequestorId,
                request.DiscipleId);

            return result;
        }
    }
}
