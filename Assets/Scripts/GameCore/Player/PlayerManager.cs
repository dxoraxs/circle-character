using CircleCharacter.Constants.GameCore;
using UniRx;
using UnityEngine.Scripting;

namespace CircleCharacter.GameCore.Player
{
    public class PlayerManager
    {
        private Player _player;

        public void SetCharacterContainer(Player characterContainer)
        {
            _player = characterContainer;
        }
    }
}