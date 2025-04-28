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
        public void Initialize()
        {
            Application.targetFrameRate = 60;
            StartInitialization().Forget();
        }

        private async UniTaskVoid StartInitialization()
        {
            await WaitLoadScene();
        }

        private async UniTask WaitLoadScene()
        {
            await new LoadSceneTask(Constants.MainScene).LoadAsync();
        }
    }
}