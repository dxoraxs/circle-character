using CircleCharacter.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine.Scripting;

namespace Initialization.LoadingTasks
{
    public class InitializeConfigsServiceTask: ILoadingTask
    {
        private readonly IConfigsService _configsService;

        [Preserve]
        public InitializeConfigsServiceTask(IConfigsService configsService)
        {
            _configsService = configsService;
        }

        public UniTask LoadAsync()
        {
            return _configsService.Initialize();
        }
    }
}