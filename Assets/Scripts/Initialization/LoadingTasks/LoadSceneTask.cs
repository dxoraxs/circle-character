using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Initialization.LoadingTasks
{
    public class LoadSceneTask : ILoadingTask
    {
        private readonly string _sceneName;

        public LoadSceneTask(string sceneName)
        {
            _sceneName = sceneName;
        }

        public UniTask LoadAsync()
        {
            return SceneManager.LoadSceneAsync(_sceneName).ToUniTask();
        }
    }
}