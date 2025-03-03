using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Commands.RemoveDisciple
{
    public class RemoveDiscipleHandler(IJmDbContext dbContext) : IRequestHandler<RemoveDiscipleCommand, string>
    {
        public async Task<string> Handle(RemoveDiscipleCommand request, CancellationToken cancellationToken)
        {
            var disciple = await dbContext.PersonalInfo
                .Include(disciple => disciple.Cell)
                .FirstOrDefaultAsync(person => person.Id == request.Document, cancellationToken) ??
                throw new NotFoundException<Cell>(request.Document);

            if (disciple.CellId == null)
                throw new Exception("This person does not belong to any cell");

            if (disciple.CellId != request.CellId)
                throw new Exception("This person does not belong to the given cell");

            disciple.CellId = null;
            disciple.Cell = null;
            disciple.MinistryStatus = MinistryStatus.Unknown;

            dbContext.PersonalInfo.Update(disciple);
            await dbContext.SaveChangesAsync(cancellationToken);

            return $"Disciple {request.Document} was removed successfully from cell {request.CellId}";
        }
    }
}
