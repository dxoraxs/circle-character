using System;
using UniRx;
using UnityEngine.Scripting;

namespace CircleCharacter.Constants.UI
{
    public class GamePresenter : BasePresenter<GameView>
    {
        public event Action OnJumpClicked;
        private readonly BoolReactiveProperty _leftDirectionButtonIsPressed = new();
        private readonly BoolReactiveProperty _rightDirectionButtonIsPressed = new();

        public IReadOnlyReactiveProperty<bool> LeftDirectionStream => _leftDirectionButtonIsPressed;
        public IReadOnlyReactiveProperty<bool> RightDirectionStream => _rightDirectionButtonIsPressed;
        
        [Preserve]
        public GamePresenter(GameView view) : base(view)
        {
            view.Initialize(this);
        }

        public void OnClickJump()
        {
            OnJumpClicked?.Invoke();
        }

        public void OnLeftDirectionPressed(bool value)
        {
            _leftDirectionButtonIsPressed.Value = value;
        }

        public void OnRightDirectionPressed(bool value)
        {
            _rightDirectionButtonIsPressed.Value = value;
        }
    }
}