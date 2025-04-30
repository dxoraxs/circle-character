using CircleCharacter.Constants.GameCore;
using UniRx;
using UnityEngine.Scripting;

namespace CircleCharacter.GameCore.Player
{
    public class PlayerInstaller
    {
        private readonly IInputController _inputController;
        private readonly PlayerManager _playerManager;
        private CompositeDisposable _compositeDisposable;

        [Preserve]
        public PlayerInstaller(IInputController inputController, PlayerManager playerManager)
        {
            _inputController = inputController;
            _playerManager = playerManager;
        }

        public void SetNewPlayer(Character character)
        {
            _compositeDisposable?.Dispose();
            _compositeDisposable = new CompositeDisposable();
            
            var player = new Player(character);

            _inputController.OnJumpClickEvent += player.Character.CharacterMovement.TryJumpButton;
            _compositeDisposable.Add(Disposable.Create(() => 
                _inputController.OnJumpClickEvent -= player.Character.CharacterMovement.TryJumpButton));
            
            Observable.EveryUpdate().Subscribe(_ => player.Character.CharacterMovement.SetDirection(
                    _inputController.HorizontalInput)).AddTo(_compositeDisposable);
            
            _playerManager.SetCharacterContainer(player);
        }
    }
}