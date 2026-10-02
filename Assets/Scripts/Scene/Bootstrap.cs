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
        SceneManager.LoadScene("SceneLoadingScreen", LoadSceneMode.Single);

        SceneManager.LoadScene("SceneSystem", LoadSceneMode.Additive);
        SceneManager.LoadScene("SceneCameraMain", LoadSceneMode.Additive);
        // SceneManager.LoadScene("LightingGlobal", LoadSceneMode.Additive);

        await Addressables.InitializeAsync().Task;
        await DatabaseManager.Instance.InitializeAsync();

        #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (debugConfig.IsBootToDebugMainMenu)
                SceneLoaderManager.Instance.LoadGroup("SceneGroupData-DebugMainMenu");
            else
                SceneLoaderManager.Instance.LoadGroup("SceneGroupData-MainMenu");
        #else
            // SceneLoader.Instance.LoadGroup("SceneGroupData-MainMenu");
            SceneLoaderManager.Instance.LoadGroup("SceneGroupData-DebugMainMenu");
        #endif

        await SceneManager.UnloadSceneAsync("SceneLoadingScreen");
    }

    private void InitializeGame() 
    {
        CustomLog.Initialize(debugConfig);
        AddressableLoader.Initialize(addressableConfig);
        AddressableBuilder.Initialize(addressableConfig);
    }
}
