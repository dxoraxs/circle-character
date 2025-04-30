using System;

namespace CircleCharacter.Constants.GameCore
{
    public interface IInputController
    {
        event Action OnJumpClickEvent;
        float HorizontalInput { get; }
        void SetHorizontalInput(float value);
        void OnJumpClicked();
    }
}