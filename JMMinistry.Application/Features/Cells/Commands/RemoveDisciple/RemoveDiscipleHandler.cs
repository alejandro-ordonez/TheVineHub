using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Commands.RemoveDisciple
{
    public class RemoveDiscipleHandler(IJmDbContext dbContext, AppMapper mapper) : ICommandHandler<RemoveDiscipleCommand, IList<PartialUserInfoDto>>
    {
        public async ValueTask<IList<PartialUserInfoDto>> Handle(RemoveDiscipleCommand request, CancellationToken cancellationToken)
        {
            var disciple = await dbContext.PersonalInfo
                .FirstOrDefaultAsync(person => person.Id == request.Document, cancellationToken) ??
                throw new NotFoundException<Cell>(request.Document);

            if (disciple.CellId == null)
                throw new Exception("This person does not belong to any cell");

            if (disciple.CellId != request.CellId)
                throw new Exception("This person does not belong to the given cell");

            var cell = await dbContext.Cells
                .Include(c => c.Disciples)
                .FirstOrDefaultAsync(cell => cell.Id == request.CellId, cancellationToken) ?? throw new NotFoundException<Cell>(request.CellId.ToString());

            cell.Disciples.Remove(disciple);

            dbContext.PersonalInfo.Update(disciple);
            dbContext.Cells.Update(cell);

            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.PersonalInfoCollectionToPartialUserInfoDtoList(cell.Disciples);
        }
    }
}
