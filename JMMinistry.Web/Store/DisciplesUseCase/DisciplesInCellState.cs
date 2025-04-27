using Fluxor;
using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Web.Store.DisciplesUseCase
{
    [FeatureState]
    public record DisciplesInCellState : BaseState
    {
        public int CellId { get; set; }
        public IList<PartialUserInfoDto> Disciples { get; set; } = [];
    }
}
