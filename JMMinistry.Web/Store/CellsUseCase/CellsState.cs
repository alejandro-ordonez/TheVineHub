using Fluxor;
using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Store.CellsUseCase
{
    [FeatureState]
    public record CellsState: BaseState
    {
        public IList<CellDto> Cells { get; set; }

        public CellsState() 
        {
            Cells = [];
        }

        public CellsState(bool isLoading, IList<CellDto> cells)
        {
            IsLoading = isLoading;
            Cells = cells;
        }
    }
}
