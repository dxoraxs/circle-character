using UnityEngine;

namespace CircleCharacter.Constants.GameCore.Level
{
    public class LevelContainer : MonoBehaviour
    {
        [field: SerializeField] public Transform SpawnPoint { get; private set; }
    }
}