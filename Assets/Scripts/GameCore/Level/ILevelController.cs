using UnityEngine;

namespace CircleCharacter.Constants.GameCore.Level
{
    public interface ILevelController
    {
        void SpawnLevel();
        Vector3 SpawnPlayerPoint { get; }
    }
}