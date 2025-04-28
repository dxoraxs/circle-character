namespace CircleCharacter.Constants.UI
{
    public class BasePresenter<TView> where TView : BaseView
    {
        protected readonly TView View;

        protected BasePresenter(TView view)
        {
            View = view;
        }
    }
}