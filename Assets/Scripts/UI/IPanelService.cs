using System;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace CircleCharacter.Constants.UI
{
    public interface IPanelService
    {
        UniTask Initialize();
        TView Get<TView>() where TView : BaseView;
    }
}