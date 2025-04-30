using System;
using UniRx;

namespace CircleCharacter.Constants.GameCore
{
    public class InputController : IInputController
    {
        public event Action OnJumpClickEvent;
        public float HorizontalInput { get; private set; }

        public void SetHorizontalInput(float value)
        {
            HorizontalInput = value;
        }
        
        public void OnJumpClicked()
        {
            OnJumpClickEvent?.Invoke();
        }
    }
}