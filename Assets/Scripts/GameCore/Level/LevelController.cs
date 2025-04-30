using CircleCharacter.Configs;
using UnityEngine;
using UnityEngine.Scripting;
using VContainer.Unity;

namespace CircleCharacter.Constants.GameCore.Level
{
    public class LevelController : ILevelController
    {
        private readonly IConfigsService _configsService;
        private LevelContainer _levelContainer;

        public Vector3 SpawnPlayerPoint => _levelContainer.SpawnPoint.position;

        [Preserve]
        public LevelController(IConfigsService configsService)
        {
            _configsService = configsService;
        }

        public void SpawnLevel()
        {
            var levelPrefab = _configsService.Get<PrefabsConfig>().LevelContainer;
            _levelContainer = Object.Instantiate(levelPrefab);
        }
    }
}