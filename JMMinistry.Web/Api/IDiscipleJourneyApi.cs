using JMMinistry.Common;
using JMMinistry.Common.Dtos.DiscipleJourney;

namespace JMMinistry.Web.Api
{
    public interface IDiscipleJourneyApi
    {
        Task<Response<IList<DiscipleStepDto>>?> GetStepsAsync();
        Task<Response<DiscipleStepDto>?> CreateStepAsync(CreateDiscipleStepDto dto);
        Task<Response<DiscipleStepDto>?> UpdateStepAsync(int stepId, UpdateDiscipleStepDto dto);
        Task<bool> DeleteStepAsync(int stepId);
        Task<Response<IList<StepDisciplesByCellDto>>?> GetStepDisciplesAsync(int stepId, int? cellId = null);
        Task<Response<IList<StepDisciplesByCellDto>>?> GetEligibleDisciplesAsync(int stepId);
        Task<bool> CompleteStepAsync(int stepId, CompleteStepDto dto);
        Task<bool> UpdateStepCompletionAsync(int stepId, string discipleId, UpdateStepCompletionDto dto);
    }
}
