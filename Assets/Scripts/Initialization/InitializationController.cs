using CircleCharacter.Constants;
using CircleCharacter.DI.Factories;
using Cysharp.Threading.Tasks;
using Initialization.LoadingTasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Initialization
{
    public class InitializationController : IInitializable
    {
        private readonly IIocFactory _iocFactory;

        [UnityEngine.Scripting.Preserve]
        public InitializationController(IIocFactory iocFactory)
        {
            _iocFactory = iocFactory;
        }

        public void Initialize()
        {
            Application.targetFrameRate = 60;
            StartInitialization().Forget();
        }

        private async UniTaskVoid StartInitialization()
        {
            await WaitConfigLoad();
            await WaitPanelsLoad();
            await WaitLoadScene();
        }

        private async UniTask WaitConfigLoad()
        {
            await _iocFactory.Create<InitializeConfigsServiceTask>().LoadAsync();
        }

        private async UniTask WaitPanelsLoad()
        {
            await _iocFactory.Create<InitializePanelServiceTask>().LoadAsync();
        }

        private async UniTask WaitLoadScene()
        {
            await new LoadSceneTask(Constants.MainScene).LoadAsync();
        }
    }
}