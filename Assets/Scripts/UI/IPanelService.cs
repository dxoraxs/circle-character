using System;
using CircleCharacter.UI.Views;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace CircleCharacter.UI
{
    public interface IPanelService
    {
        UniTask Initialize();
        TView Get<TView>() where TView : BaseView;
    }
}