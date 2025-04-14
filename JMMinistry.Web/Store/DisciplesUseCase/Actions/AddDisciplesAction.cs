using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Web.Store.DisciplesUseCase.Actions
{
    public record AddDisciplesAction
    {
        public int CellId { get; set; }
        public IList<string> Documents { get; set; } = [];
    }

    public record AddDisciplesResultAction
    {
        public int CellId { get; set; }
        public IList<PartialUserInfoDto> Disciples { get; set; } = [];
    }
}
