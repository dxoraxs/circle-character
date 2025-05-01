using Cysharp.Threading.Tasks;

namespace CircleCharacter.UI.Views.GameView
{
    public interface IGamePresenter
    {
        void OnClickJump();
        UniTask Initialize();
        void OnLeftDirectionPressed(bool value);
        void OnRightDirectionPressed(bool value);
    }
}