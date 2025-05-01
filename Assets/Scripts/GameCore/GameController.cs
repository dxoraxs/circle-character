using CircleCharacter.Constants.GameCore.Level;
using CircleCharacter.DI.Factories;
using CircleCharacter.GameCore.Player;
using CircleCharacter.UI.Views.GameView;
using Cysharp.Threading.Tasks;
using Initialization.LoadingTasks;
using UnityEngine;
using UnityEngine.Scripting;
using VContainer.Unity;

namespace CircleCharacter.GameCore
{
    public class GameController : IInitializable
    {
        private readonly IIocFactory _iocFactory;
        private readonly ILevelController _levelController;
        
        [Preserve]
        public GameController(IIocFactory iocFactory, ILevelController levelController)
        {
            _iocFactory = iocFactory;
            _levelController = levelController;
        }

        public void Initialize()
        {
            StartGameCore().Forget();
        }

        private async UniTaskVoid StartGameCore()
        {
            await WaitConfigLoad();
            await WaitPanelsLoad();
            _levelController.SpawnLevel();

            await _iocFactory.Create<GamePresenter>().Initialize();
            
            var characterInstaller = _iocFactory.Create<CharacterInstaller>();
            var character = characterInstaller.Create(_levelController.SpawnPlayerPoint);

            var playerInstaller = _iocFactory.Create<PlayerInstaller>();
            playerInstaller.Create(character);
        }
        
        private async UniTask WaitConfigLoad()
        {
            await _iocFactory.Create<InitializeConfigsServiceTask>().LoadAsync();
        }
        
        private async UniTask WaitPanelsLoad()
        {
            await _iocFactory.Create<InitializePanelServiceTask>().LoadAsync();
        }
    }
}