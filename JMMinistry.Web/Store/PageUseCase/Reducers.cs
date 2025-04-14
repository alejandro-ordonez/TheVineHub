using Fluxor;

namespace JMMinistry.Web.Store.PageUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static PageState ReducePageTitle(PageState state, SetTitleAction action)
            => state with { Title = action.Title };
    }
}
