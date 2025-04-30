using CircleCharacter.Constants.GameCore;
using UniRx;
using UnityEngine.Scripting;

namespace CircleCharacter.GameCore.Player
{
    public class PlayerManager
    {
        private readonly CameraController _cameraController;
        private Player _player;

        [Preserve]
        public PlayerManager(CameraController cameraController)
        {
            _cameraController = cameraController;
        }

        public void SetCharacterContainer(Player characterContainer)
        {
            _player = characterContainer;
            _cameraController.SetTarget(_player.Character.CharacterContainer.transform);
        }
    }
}