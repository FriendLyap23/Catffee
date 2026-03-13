using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IncrementalGameTemplateMVVMBased
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        private void Awake()
        {
            Load().Forget();
        }

        private async UniTaskVoid Load()
        {
            await SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);

            Debug.Log($"The {_sceneName} scene has been uploaded successfully!");
        }
    }
}