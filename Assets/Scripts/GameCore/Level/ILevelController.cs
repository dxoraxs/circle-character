using UnityEngine;

namespace CircleCharacter.Constants.GameCore.Level
{
    public interface ILevelController
    {
        void SpawnLevel();
        Transform SpawnPlayerPoint { get; }
    }
}