using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

public class Bootstrap : MonoBehaviour 
{
    [SerializeField] private DebugConfig debugConfig;
    [SerializeField] private AddressableConfig addressableConfig;

    private async void Awake() 
    {
        InitializeGame();
        await BootGameAsync();
    }

    private async Task BootGameAsync()
    {
        SceneManager.LoadScene("LoadingScene", LoadSceneMode.Single);

        SceneManager.LoadScene("MainCamera", LoadSceneMode.Additive);
        SceneManager.LoadScene("SystemManager", LoadSceneMode.Additive);
        SceneManager.LoadScene("GlobalLighting", LoadSceneMode.Additive);

        await Addressables.InitializeAsync().Task;
        await DatabaseManager.Instance.InitializeAsync();

        //await SceneManager.UnloadSceneAsync("LoadingScene");

        #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (debugConfig.IsBootToDebugMainMenu)
                SceneLoaderManager.Instance.LoadGroup("sceneDebugMainMenu");
            else
                SceneLoaderManager.Instance.LoadGroup("sceneDebugMainMenu");
        #else
            SceneLoader.Instance.LoadGroup("sceneMainMenu");
        #endif
    }

    private void InitializeGame() 
    {
        CustomLog.Initialize(debugConfig);
        AddressableLoader.Initialize(addressableConfig);
        AddressableBuilder.Initialize(addressableConfig);
    }
}
