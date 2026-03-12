using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.User.Commands.MarryLeaders;

public class MarryLeadersHandler(IJmDbContext dbContext)
    : ICommandHandler<MarryLeadersCommand>
{
    public async ValueTask<Unit> Handle(MarryLeadersCommand request, CancellationToken cancellationToken)
    {
        // Verify requestor is a leader of at least one cell containing both persons
        var requestorCellIds = await dbContext.Cells
            .Where(c => c.Leaders.Any(l => l.Id == request.RequestorId))
            .Select(c => c.Id)
            .ToListAsync(cancellationToken);

        if (requestorCellIds.Count == 0)
            throw new InvalidOperationException("You must be a cell leader to perform this action.");

        var person = await dbContext.PersonalInfo
            .Include(p => p.Cells)
            .FirstOrDefaultAsync(p => p.Id == request.PersonId, cancellationToken)
            ?? throw new NotFoundException<PersonalInfo>(request.PersonId);

        var spouse = await dbContext.PersonalInfo
            .Include(p => p.Cells)
            .FirstOrDefaultAsync(p => p.Id == request.SpouseId, cancellationToken)
            ?? throw new NotFoundException<PersonalInfo>(request.SpouseId);

        // Both must be in the same cell, and that cell must be led by the requestor
        if (!person.CellId.HasValue || !spouse.CellId.HasValue
            || person.CellId != spouse.CellId
            || !requestorCellIds.Contains(person.CellId.Value))
            throw new InvalidOperationException("Both persons must be in the same cell led by you. Please move them to your cell first.");

        // If already married to each other, nothing to do
        if (person.SpouseId == spouse.Id)
            return Unit.Value;

        // Update marital status
        person.MaritalStatus = MaritalStatus.Married;
        spouse.MaritalStatus = MaritalStatus.Married;

        // Set spouse relationship (EF Core handles the one-to-one inverse automatically)
        person.SpouseId = spouse.Id;

        // Add spouse as leader to all cells where the person is a leader (and vice versa)
        var personCellIds = person.Cells.Select(c => c.Id).ToHashSet();
        var spouseCellIds = spouse.Cells.Select(c => c.Id).ToHashSet();

        var cellsToAddSpouse = person.Cells
            .Where(c => !spouseCellIds.Contains(c.Id))
            .ToList();

        foreach (var cell in cellsToAddSpouse)
            spouse.Cells.Add(cell);

        var cellsToAddPerson = spouse.Cells
            .Where(c => !personCellIds.Contains(c.Id))
            .ToList();

        foreach (var cell in cellsToAddPerson)
            person.Cells.Add(cell);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
