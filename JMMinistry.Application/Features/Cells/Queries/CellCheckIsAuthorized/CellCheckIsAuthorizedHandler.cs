using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common;
using JMMinistry.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized
{
    public class CellCheckIsAuthorizedHandler(IJmDbContext dbContext, UserManager<PersonalInfo> userManager) : IRequestHandler<CellCheckIsAuthorizedQuery, bool>
    {
        public async Task<bool> Handle(CellCheckIsAuthorizedQuery request, CancellationToken cancellationToken)
        {
            IList<Roles> authorizedRoles = [.. request.AllowedRoles, Roles.Admin, Roles.Attendance, Roles.Cells];

            var user = new PersonalInfo { Id = request.RequestorId };
            var userRoles = await userManager.GetRolesAsync(user);

            var isAuthorized = userRoles.Any(role => authorizedRoles.Contains(Enum.Parse<Roles>(role)));

            isAuthorized |= await CheckIfLeader(request.CellId, request.RequestorId);

            return isAuthorized;
        }

        private async Task<bool> CheckIfLeader(int cellId, string leaderId)
        {
            var cell = await dbContext.Cells
                .Include(cell => cell.Leaders)
                .FirstOrDefaultAsync(cell => cell.Id == cellId)
                ?? throw new NotFoundException("The requested cell doesn't exists");

            if (cell.Leaders.Any(leader => leader.Id == leaderId))
                return true;

            foreach (var leaderCellId in cell.Leaders.Select(leader => leader.CellId))
            {
                if (leaderCellId is null)
                    continue;

                if (await CheckIfLeader(leaderCellId.Value, leaderId))
                    return true;
            }

            return false;
        }
    }
}
