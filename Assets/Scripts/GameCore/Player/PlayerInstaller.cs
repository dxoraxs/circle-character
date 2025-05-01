using CircleCharacter.Constants.GameCore;
using UniRx;
using UnityEngine.Scripting;

namespace CircleCharacter.GameCore.Player
{
    public class PlayerInstaller
    {
        private readonly IInputController _inputController;
        private readonly PlayerManager _playerManager;
        private readonly CameraController _cameraController;
        private CompositeDisposable _compositeDisposable;

        [Preserve]
        public PlayerInstaller(IInputController inputController, PlayerManager playerManager, CameraController cameraController)
        {
            _inputController = inputController;
            _playerManager = playerManager;
            _cameraController = cameraController;
        }

        public Player Create(Character character)
        {
            _compositeDisposable?.Dispose();
            _compositeDisposable = new CompositeDisposable();
            
            var player = new Player(character);
            
            _cameraController.SetTarget(character.CharacterContainer.transform);

            _inputController.OnJumpClickEvent += player.Character.CharacterMovement.TryJump;
            _compositeDisposable.Add(Disposable.Create(() => 
                _inputController.OnJumpClickEvent -= player.Character.CharacterMovement.TryJump));
            
            Observable.EveryUpdate().Subscribe(_ => player.Character.CharacterMovement.SetDirection(
                    _inputController.HorizontalInput)).AddTo(_compositeDisposable);
            
            _playerManager.SetCharacterContainer(player);

            return player;
        }
    }
}