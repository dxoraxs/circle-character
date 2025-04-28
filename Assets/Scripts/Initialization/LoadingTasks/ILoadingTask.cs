using Cysharp.Threading.Tasks;

namespace Initialization.LoadingTasks
{
    public interface ILoadingTask
    {
        UniTask LoadAsync();
    }
}