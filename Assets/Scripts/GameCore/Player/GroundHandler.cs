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
        private readonly PlayerContainer _characterContainer;
        
        private readonly BoolReactiveProperty _isGrounded = new();
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly Collider2D[] _collider2D = new Collider2D[2];

        public bool IsGrounded => _isGrounded.Value;
        public IReadOnlyReactiveProperty<bool> IsGroundedProperty => _isGrounded;

        [Preserve]
        public GroundHandler(IConfigsService configsService, ICharacterManager characterManager)
        {
            _configsService = configsService;
            _characterContainer = characterManager.PlayerContainer;
            _characterSettings = _configsService.Get<CharacterSettings>();

            Observable.EveryFixedUpdate().Subscribe(_ => CheckGround()).AddTo(_compositeDisposable);
        }

        private void CheckGround()
        {
            var originOverlap = _characterContainer.transform.position + Vector3.up * _characterSettings.VerticalOffsetGroundCast;
            var radius = _characterContainer.Collider.radius;
            var count = Physics2D.OverlapCircleNonAlloc(originOverlap, radius, _collider2D);
            
            _isGrounded.Value = count > 1;
        }
    }
}