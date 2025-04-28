using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Scripting;
using VContainer.Unity;

namespace CircleCharacter.UI.Views.GameView
{
    public class GamePresenter : BasePresenter<GameView>
    {
        public event Action OnJumpClicked;
        private readonly BoolReactiveProperty _leftDirectionButtonIsPressed = new();
        private readonly BoolReactiveProperty _rightDirectionButtonIsPressed = new();

        public IReadOnlyReactiveProperty<bool> LeftDirectionStream => _leftDirectionButtonIsPressed;
        public IReadOnlyReactiveProperty<bool> RightDirectionStream => _rightDirectionButtonIsPressed;

        [Preserve]
        public GamePresenter(IPanelService panelService) : base(panelService)
        {
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

        public UniTask Initialize()
        {
            View.Initialize(this);
            View.SetEnabled(true);

            return UniTask.CompletedTask;
        }
    }
}