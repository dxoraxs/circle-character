using System;
using CircleCharacter.Configs;
using CircleCharacter.Configs.Data;
using CircleCharacter.UI.Views.GameView;
using UniRx;
using UnityEngine;
using UnityEngine.Scripting;

namespace CircleCharacter.GameCore.Player
{
    public class PlayerMovement : IDisposable
    {
        private readonly ICharacterManager _characterManager;
        private readonly GamePresenter _gamePresenter;
        private readonly GroundHandler _groundHandler;
        private readonly IConfigsService _configsService;
        private readonly Rigidbody2D _character;
        private readonly CharacterSettings _characterSettings;
        private readonly CompositeDisposable _compositeDisposable = new();
        private bool _leftPressed;
        private bool _rightPressed;

        [Preserve]
        public PlayerMovement(ICharacterManager characterManager, GamePresenter gamePresenter, IConfigsService configsService,
            GroundHandler groundHandler)
        {
            _characterManager = characterManager;
            _gamePresenter = gamePresenter;
            _configsService = configsService;
            _groundHandler = groundHandler;

            _characterSettings = _configsService.Get<CharacterSettings>();
            _character = _characterManager.PlayerContainer.Rigidbody;
            
            _gamePresenter.OnJumpClicked += OnClickJumpButton;
            _gamePresenter.LeftDirectionStream.Subscribe(OnInteractLeftDirection).AddTo(_compositeDisposable);
            _gamePresenter.RightDirectionStream.Subscribe(OnInteractRightDirection).AddTo(_compositeDisposable);

            Observable.EveryFixedUpdate().Subscribe(_ => FixedUpdate()).AddTo(_compositeDisposable);
        }

        private void FixedUpdate()
        {
            if (_leftPressed)
            {
                if (_character.angularVelocity < _characterSettings.MaxRotateSpeed)
                {
                    _character.AddTorque(_characterSettings.TorqueForce, ForceMode2D.Force);

                    if (_character.angularVelocity > _characterSettings.MaxRotateSpeed)
                    {
                        _character.angularVelocity = _characterSettings.MaxRotateSpeed;
                    }
                }
            }
            else if (_rightPressed)
            {
                if (_character.angularVelocity > -_characterSettings.MaxRotateSpeed)
                {
                    _character.AddTorque(-_characterSettings.TorqueForce, ForceMode2D.Force);

                    if (_character.angularVelocity < -_characterSettings.MaxRotateSpeed)
                    {
                        _character.angularVelocity = -_characterSettings.MaxRotateSpeed;
                    }
                }
            }
        }

        private void OnInteractLeftDirection(bool value)
        {
            _leftPressed = value;
        }

        private void OnInteractRightDirection(bool value)
        {
            _rightPressed = value;
        }

        private void OnClickJumpButton()
        {
            if (_groundHandler.IsGrounded)
            {
                _character.AddForce(Vector2.up * _characterSettings.JumpForce, ForceMode2D.Impulse);
            }
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}