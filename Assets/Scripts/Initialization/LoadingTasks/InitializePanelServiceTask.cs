using CircleCharacter.Configs;
using CircleCharacter.Constants.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.Scripting;

namespace Initialization.LoadingTasks
{
    public class InitializePanelServiceTask: ILoadingTask
    {
        private readonly IPanelService _panelService;

        [Preserve]
        public InitializePanelServiceTask(IPanelService panelService)
        {
            _panelService = panelService;
        }

        public UniTask LoadAsync()
        {
            return _panelService.Initialize();
        }
    }
}