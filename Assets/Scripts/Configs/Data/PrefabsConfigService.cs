using CircleCharacter.Constants.GameCore.Level;
using CircleCharacter.GameCore.Player;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CircleCharacter.Configs
{
    [CreateAssetMenu(fileName = "prefabs_config_service", menuName = "Create " + nameof(PrefabsConfig),
        order = 0)]
    public class PrefabsConfig : ScriptableObject
    {
        [field: SerializeField] public PlayerContainer PlayerPrefab { get; private set; }
        [field: SerializeField] public LevelContainer LevelContainer { get; private set; }
    }
}