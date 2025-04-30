using System;
using CircleCharacter.Configs;
using CircleCharacter.Configs.Data;
using CircleCharacter.Constants.GameCore;
using CircleCharacter.UI.Views.GameView;
using UniRx;
using UnityEngine;
using UnityEngine.Scripting;

namespace CircleCharacter.GameCore.Player
{
    public class CharacterMovement : IDisposable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly GroundHandler _groundHandler;
        private readonly IConfigsService _configsService;
        private readonly CharacterSettings _characterSettings;
        private readonly CompositeDisposable _compositeDisposable = new();
        private float _moveDirection;

        [Preserve]
        public CharacterMovement(IConfigsService configsService, Rigidbody2D rigidbody,
            GroundHandler groundHandler)
        {
            _rigidbody = rigidbody;
            _configsService = configsService;
            _groundHandler = groundHandler;

            _characterSettings = _configsService.Get<CharacterSettings>();

            Observable.EveryFixedUpdate().Subscribe(_ => FixedUpdate()).AddTo(_compositeDisposable);
        }

        public void SetDirection(float direction)
        {
            _moveDirection = direction;
        }

        public void TryJumpButton()
        {
            if (_groundHandler.IsGrounded)
            {
                var jumpForce = Vector2.up * _characterSettings.JumpForce;
                _rigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.AddTorque(_moveDirection * _characterSettings.TorqueForce, ForceMode2D.Force);

            _rigidbody.angularVelocity = Mathf.Clamp(_rigidbody.angularVelocity, -_characterSettings.MaxRotateSpeed,
                _characterSettings.MaxRotateSpeed);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}