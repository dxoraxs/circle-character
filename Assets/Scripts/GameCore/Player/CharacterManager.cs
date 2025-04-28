using CircleCharacter.Configs;
using CircleCharacter.Constants.GameCore.Level;
using UnityEngine;
using UnityEngine.Scripting;
using VContainer.Unity;

namespace CircleCharacter.GameCore.Player
{
    public class CharacterManager : ICharacterManager
    {
        private readonly IConfigsService _configsService;
        private readonly ILevelController _levelController;
        private PlayerContainer _playerContainer;
        
        public PlayerContainer PlayerContainer => _playerContainer;

        [Preserve]
        public CharacterManager(IConfigsService configsService, ILevelController levelController)
        {
            _configsService = configsService;
            _levelController = levelController;
        }

        public void Initialize()
        {
            SpawnCharacter();
        }

        private void SpawnCharacter()
        {
            var playerPrefab = _configsService.Get<PrefabsConfig>().PlayerPrefab;
            var spawnPoint = _levelController.SpawnPlayerPoint.position;
            _playerContainer = Object.Instantiate(playerPrefab);
            
            _playerContainer.transform.position = spawnPoint;
        }
    }
}