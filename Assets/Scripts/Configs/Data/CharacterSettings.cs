using UnityEngine;

namespace CircleCharacter.Configs.Data
{
    [CreateAssetMenu(fileName = "character_settings", menuName = "Create " + nameof(CharacterSettings), order = 0)]
    public class CharacterSettings : ScriptableObject
    {
        [field: SerializeField] public float ForceTorque { get; private set; }
        [field: SerializeField] public float MaxRotateSpeed { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
    }
}