using AutoMapper;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Commands.AddDisciples;

public class AddDisciplesHandler(IJmDbContext dbContext, IMapper mapper) :
    IRequestHandler<AddDisciplesCommand, List<PartialUserInfoDto>>
{
    public async Task<List<PartialUserInfoDto>> Handle(AddDisciplesCommand request, CancellationToken cancellationToken)
    {
        var users = await dbContext.PersonalInfo
            .Where(user => request.Documents.Contains(user.Id))
            .ToListAsync(cancellationToken);

        if (users.Count != request.Documents.Count)
            throw new ArgumentException("There were users that do not exists");

        var cell = await dbContext.Cells
            .FirstOrDefaultAsync(cell => cell.Id == request.CellId, cancellationToken) ??
            throw new NotFoundException<Cell>(request.CellId.ToString());

        foreach (var disciple in users)
        {
            disciple.CellEnrollmentDate = DateTime.Now;
            disciple.MinistryStatus = MinistryStatus.InACell;
            cell.Disciples.Add(disciple);
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return mapper.Map<List<PartialUserInfoDto>>(cell.Disciples);
    }
}
