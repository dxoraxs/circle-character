using System;
using CircleCharacter.Configs;
using CircleCharacter.GameCore.Player;
using Configs.Data;
using UniRx;
using UnityEngine;
using UnityEngine.Scripting;

namespace CircleCharacter.Constants.GameCore
{
    public class CameraController : IDisposable
    {
        private readonly Camera _camera;
        private readonly IConfigsService _configsService;
        private readonly ICharacterManager _characterManager;
        
        private readonly CameraSettings _cameraSettings;
        private readonly Transform _targetFollow;
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly float _defaultZPosition;
        
        [Preserve]
        public CameraController(Camera camera, IConfigsService configsService, ICharacterManager characterManager)
        {
            _camera = camera;
            _configsService = configsService;
            _characterManager = characterManager;

            _cameraSettings = _configsService.Get<CameraSettings>();
            _targetFollow = _characterManager.PlayerContainer.transform;
            _defaultZPosition = _camera.transform.position.z;

            Observable.EveryLateUpdate().Subscribe(_ => Update()).AddTo(_compositeDisposable);
        }

        private void Update()
        {
            var targetPosition = _targetFollow.position;
            targetPosition.z = _defaultZPosition;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition, _cameraSettings.Speed * Time.deltaTime);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}