using UnityEngine;

namespace Configs.Data
{
    [CreateAssetMenu(fileName = "camera_settings", menuName = "Create " + nameof(CameraSettings), order = 0)]
    public class CameraSettings : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
    }
}