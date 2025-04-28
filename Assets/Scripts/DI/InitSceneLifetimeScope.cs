using CircleCharacter.Configs;
using CircleCharacter.Configs.Data;
using CircleCharacter.Constants.UI;
using CircleCharacter.DI.Factories;
using Initialization;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CircleCharacter.DI
{
    public class InitSceneLifetimeScope : LifetimeScope
    {
        [SerializeField] private ConfigsService _configsService;
        [SerializeField] private PanelService _panelService;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<VContainerFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterInstance(_configsService).As<IConfigsService>();
            builder.RegisterInstance(_panelService).As<IPanelService>();
            
            builder.RegisterEntryPoint<InitializationController>();
        }
    }
}