using Fluxor;
using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Store.MinistryUseCase
{
    [FeatureState]
    public record MinistryState : BaseState
    {
        public IList<CellDto> Cells { get; set; }

        public MinistryState()
        {
            Cells = [];
        }

        public MinistryState(bool isLoading, IList<CellDto> cells)
        {
            IsLoading = isLoading;
            Cells = cells;
        }
    }
}
