using CircleCharacter.Configs;
using CircleCharacter.Configs.Data;
using UniRx;
using UnityEngine;
using UnityEngine.Scripting;

namespace CircleCharacter.GameCore.Player
{
    public class GroundHandler
    {
        private readonly IConfigsService _configsService;
        private readonly CharacterSettings _characterSettings;
        private readonly Transform _transform;
        private readonly float _circleRadius;
        
        private readonly BoolReactiveProperty _isGrounded = new();
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly Collider2D[] _collider2D = new Collider2D[2];

        public bool IsGrounded => _isGrounded.Value;

        [Preserve]
        public GroundHandler(IConfigsService configsService, Transform transform, float circleRadius)
        {
            _configsService = configsService;
            _transform = transform;
            _circleRadius = circleRadius;
            _characterSettings = _configsService.Get<CharacterSettings>();

            Observable.EveryFixedUpdate().Subscribe(_ => CheckGround()).AddTo(_compositeDisposable);
        }

        private void CheckGround()
        {
            var originOverlap = _transform.position + Vector3.up * _characterSettings.VerticalOffsetGroundCast;
            var count = Physics2D.OverlapCircleNonAlloc(originOverlap, _circleRadius, _collider2D);
            
            _isGrounded.Value = count > 1;
        }
    }
}