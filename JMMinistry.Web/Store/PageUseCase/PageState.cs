using Fluxor;

namespace JMMinistry.Web.Store.PageUseCase
{
    [FeatureState]
    public record PageState
    {
        public string Title { get; set; } = string.Empty;
    }
}
