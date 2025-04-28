using CircleCharacter.Configs;
using CircleCharacter.Constants.GameCore;
using CircleCharacter.Constants.GameCore.Level;
using CircleCharacter.DI.Factories;
using CircleCharacter.GameCore.Player;
using CircleCharacter.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CircleCharacter.DI
{
    public class MainSceneLifetimeScope : LifetimeScope
    {
        [SerializeField] private ConfigsService _configsService;
        [SerializeField] private PanelService _panelService;
        [SerializeField] private Camera _camera;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<VContainerFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterInstance(_camera);
            builder.RegisterInstance(_configsService).As<IConfigsService>();
            builder.RegisterInstance(_panelService).As<IPanelService>();
            builder.Register<LevelController>(Lifetime.Singleton).As<ILevelController>();
            builder.Register<CharacterManager>(Lifetime.Singleton).As<ICharacterManager>();
            builder.RegisterEntryPoint<GameController>(Lifetime.Scoped).AsSelf();
        }
    }
}