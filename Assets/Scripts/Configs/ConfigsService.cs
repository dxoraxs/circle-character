using System;
using System.Collections.Generic;
using CircleCharacter.Configs.Data;
using Configs.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CircleCharacter.Configs
{
    [CreateAssetMenu(fileName = "configs_service", menuName = "Create " + nameof(ConfigsService), order = 0)]
    public class ConfigsService : ScriptableObject, IConfigsService
    {
        [SerializeField] private CharacterSettings _characterSettings;
        [SerializeField] private PrefabsConfig _prefabsConfig;
        [SerializeField] private CameraSettings _cameraSettings;
        private readonly Dictionary<Type, ScriptableObject> _configs = new();

        public UniTask Initialize()
        {
            AddToCache(_characterSettings);
            AddToCache(_prefabsConfig);
            AddToCache(_cameraSettings);
            
            return UniTask.CompletedTask;
        }

        public T Get<T>() where T : ScriptableObject
        {
            return (T)_configs[typeof(T)];
        }
        
        private void AddToCache<T>(T config) where T : ScriptableObject
        {
            _configs.Add(config.GetType(), config);
        }
    }
}