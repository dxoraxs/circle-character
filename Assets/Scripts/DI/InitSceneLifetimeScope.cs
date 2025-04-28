using CircleCharacter.Configs;
using CircleCharacter.Configs.Data;
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
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<VContainerFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterInstance(_configsService).As<IConfigsService>();
            builder.RegisterEntryPoint<InitializationController>();
        }
    }
}