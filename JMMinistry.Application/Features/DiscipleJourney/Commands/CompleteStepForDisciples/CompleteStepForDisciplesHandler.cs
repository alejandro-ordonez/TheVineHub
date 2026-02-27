using JMMinistry.Application.Services;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CompleteStepForDisciples;

public class CompleteStepForDisciplesHandler(IJmDbContext dbContext)
    : ICommandHandler<CompleteStepForDisciplesCommand>
{
    public async ValueTask<Unit> Handle(CompleteStepForDisciplesCommand request, CancellationToken cancellationToken)
    {
        var completions = request.DiscipleDocuments.Select(doc => new StepCompletion
        {
            DiscipleStepId = request.StepId,
            DiscipleId = doc,
            LeaderId = request.LeaderId,
            StepStatus = StepStatus.Completed,
            DateCreated = request.CompletionDate,
            LastUpdated = request.CompletionDate
        });

        dbContext.StepCompletions.AddRange(completions);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
