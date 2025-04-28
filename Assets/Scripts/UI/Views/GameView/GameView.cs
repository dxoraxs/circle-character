using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace CircleCharacter.Constants.UI
{
    public class GameView : BaseView
    {
        [SerializeField] private CustomButton _leftDirectionButton;
        [SerializeField] private CustomButton _rightDirectionButton;
        [SerializeField] private CustomButton _jumpButton;
        private GamePresenter _gamePresenter;

        private void Start()
        {
            _leftDirectionButton.OnPointerDownEvent += OnLeftButtonDown;
            _leftDirectionButton.OnPointerUpEvent += OnLeftButtonUp;

            _rightDirectionButton.OnPointerDownEvent += OnRightButtonDown;
            _rightDirectionButton.OnPointerUpEvent += OnRightButtonUp;

            _jumpButton.OnPointerClickEvent += OnClickJumpButton;
        }
 
        public void Initialize(GamePresenter gamePresenter)
        {
            _gamePresenter = gamePresenter;
        }

        private void OnLeftButtonDown()
        {
            _gamePresenter.OnLeftDirectionPressed(true);
        }

        private void OnLeftButtonUp()
        {
            _gamePresenter.OnLeftDirectionPressed(false);
        }

        private void OnRightButtonDown()
        {
            _gamePresenter.OnRightDirectionPressed(true);
        }

        private void OnRightButtonUp()
        {
            _gamePresenter.OnRightDirectionPressed(false);
        }

        private void OnClickJumpButton()
        {
            _gamePresenter.OnClickJump();
        }
    }
}