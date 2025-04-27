using Fluxor;
using JMMinistry.Common.Dtos.Cell;

namespace JMMinistry.Web.Store.CellUseCase
{
    [FeatureState]
    public record CellState : BaseState
    {
        public CellDto? Cell { get; set; }

        private CellState() { }
    }
}
