using System.Collections.Generic;
using CircleCharacter.Configs;
using CircleCharacter.Constants.GameCore;
using CircleCharacter.Constants.GameCore.Level;
using CircleCharacter.DI.Factories;
using CircleCharacter.UI.Views.GameView;
using UnityEngine;
using UnityEngine.Scripting;
using VContainer.Unity;

namespace CircleCharacter.GameCore.Player
{
    public class CharacterInstaller
    {
        private readonly IIocFactory _iocFactory;
        private readonly IConfigsService _configsService;

        [Preserve]
        public CharacterInstaller(IIocFactory iocFactory, IConfigsService configsService)
        {
            _iocFactory = iocFactory;
            _configsService = configsService;
        }

        public Character Create(Vector3 position)
        {
            var characterContainer = InstantiateCharacterContainer(position);
            var groundHandler = _iocFactory.Create<GroundHandler, Transform, float>(characterContainer.transform, characterContainer.Collider.radius);
            var playerMovement = _iocFactory.Create<CharacterMovement, Rigidbody2D, GroundHandler>(characterContainer.Rigidbody, groundHandler);

            var newCharacter = new Character(characterContainer, groundHandler, playerMovement);
            return newCharacter;
        }

        private CharacterContainer InstantiateCharacterContainer(Vector3 position)
        {
            var playerPrefab = _configsService.Get<PrefabsConfig>().CharacterPrefab;
            var characterContainer = Object.Instantiate(playerPrefab);
            
            characterContainer.transform.position = position;

            return characterContainer;
        }
    }
}