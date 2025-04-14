using JMMinistry.Common.Dtos.User;

namespace JMMinistry.Web.Store.DisciplesUseCase.Actions
{
    public record FetchDisciplesAction
    {
        public required int CellId { get; set; }
    }

    public record FetchDisciplesResultAction
    {
        public IList<PartialUserInfoDto> Disciples { get; set; }
    }
}
