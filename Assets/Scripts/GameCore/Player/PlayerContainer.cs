using UnityEngine;

namespace CircleCharacter.GameCore.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerContainer : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public CircleCollider2D Collider { get; private set; }
    }
}