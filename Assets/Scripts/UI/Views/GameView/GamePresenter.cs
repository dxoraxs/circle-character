using System;
using CircleCharacter.Constants.GameCore;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Scripting;
using VContainer.Unity;

namespace CircleCharacter.UI.Views.GameView
{
    public class GamePresenter : BasePresenter<GameView>, IGamePresenter
    {
        private readonly IInputController _inputController;
        private bool _leftDirectionButtonIsPressed;
        private bool _rightDirectionButtonIsPressed;

        [Preserve]
        public GamePresenter(IPanelService panelService, IInputController inputController) : base(panelService)
        {
            _inputController = inputController;
        }

        public void OnClickJump()
        {
            _inputController.OnJumpClicked();
        }

        public UniTask Initialize()
        {
            View.Initialize(this);
            View.SetEnabled(true);

            return UniTask.CompletedTask;
        }

        public void OnLeftDirectionPressed(bool value)
        {
            _leftDirectionButtonIsPressed = value;
            SendNewHorizontalValue();
        }

        public void OnRightDirectionPressed(bool value)
        {
            _rightDirectionButtonIsPressed = value;
            SendNewHorizontalValue();
        }

        private void SendNewHorizontalValue()
        {
            var newHorizontalValue = GetHorizontalInput();
            _inputController.SetHorizontalInput(newHorizontalValue);
        }

        private float GetHorizontalInput()
        {
            if (_leftDirectionButtonIsPressed == _rightDirectionButtonIsPressed)
            {
                return 0;
            }
            if (_leftDirectionButtonIsPressed)
            {
                return 1;
            }
            return -1;
        }
    }
}