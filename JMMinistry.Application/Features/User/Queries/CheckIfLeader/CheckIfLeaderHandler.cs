using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Queries.CheckIfLeader
{
    public class CheckIfLeaderHandler(IJmDbContext dbContext) : IRequestHandler<CheckIfLeaderQuery, bool>
    {
        public Task<bool> Handle(CheckIfLeaderQuery request, CancellationToken cancellationToken)
        {
            return CheckIfLeader(request.CellId, request.LeaderId);
        }

        private async Task<bool> CheckIfLeader(int cellId, string leaderId)
        {
            var cell = await dbContext.Cells
                .Include(cell => cell.Leaders)
                .FirstOrDefaultAsync(cell => cell.Id == cellId)
                ?? throw new NotFoundException("The requested cell doesn't exists");

            if (cell.Leaders.Any(leader => leader.Id == leaderId))
                return true;

            foreach (var leader in cell.Leaders)
            {
                if (leader.CellId is null)
                    continue;

                if (await CheckIfLeader(leader.CellId.Value, leaderId))
                    return true;
            }

            return false;
        }
    }
}
