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
        
        private readonly CameraSettings _cameraSettings;
        private readonly float _defaultZPosition;

        private IDisposable _targetFollowStream;
        private Transform _targetFollow;

        [Preserve]
        public CameraController(Camera camera, IConfigsService configsService)
        {
            _camera = camera;
            _configsService = configsService;

            _cameraSettings = _configsService.Get<CameraSettings>();
            _defaultZPosition = _camera.transform.position.z;
        }

        public void SetTarget(Transform target)
        {
            _targetFollowStream?.Dispose();

            if (target == null) return;

            _targetFollow = target;
            _targetFollowStream = Observable.EveryLateUpdate().Subscribe(_ => OnLateUpdate());
        }

        private void OnLateUpdate()
        {
            var targetPosition = _targetFollow.position;
            targetPosition.z = _defaultZPosition;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition, _cameraSettings.Speed * Time.deltaTime);
        }

        public void Dispose()
        {
            _targetFollowStream?.Dispose();
        }
    }
}