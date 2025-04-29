using CircleCharacter.Constants.GameCore.Level;
using CircleCharacter.DI.Factories;
using CircleCharacter.GameCore.Player;
using CircleCharacter.UI.Views.GameView;
using Cysharp.Threading.Tasks;
using Initialization.LoadingTasks;
using UnityEngine.Scripting;
using VContainer.Unity;

namespace CircleCharacter.Constants.GameCore
{
    public class GameController : IInitializable
    {
        private readonly IIocFactory _iocFactory;
        private readonly ILevelController _levelController;
        private readonly ICharacterManager _characterManager;
        private CameraController _cameraController;
        private PlayerMovement _playerMovement;
        private GroundHandler _groundHandler;

        [Preserve]
        public GameController(IIocFactory iocFactory, ILevelController levelController, ICharacterManager characterManager)
        {
            _iocFactory = iocFactory;
            _levelController = levelController;
            _characterManager = characterManager;
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
            _characterManager.Initialize();

            var gamePresenter = _iocFactory.Create<GamePresenter>();
            await gamePresenter.Initialize();
            _groundHandler = _iocFactory.Create<GroundHandler>();
            _playerMovement = _iocFactory.Create<PlayerMovement, GamePresenter, GroundHandler>(gamePresenter, _groundHandler);
            _cameraController = _iocFactory.Create<CameraController>();
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