namespace CircleCharacter.UI.Views
{
    public class BasePresenter<TView> where TView : BaseView
    {
        protected readonly IPanelService PanelService;
        protected readonly TView View;

        protected BasePresenter(IPanelService panelService)
        {
            PanelService = panelService;
            View = PanelService.Get<TView>();
        }
    }
}