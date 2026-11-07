using UnityEngine;
using Unity.Cinemachine;
using System.Threading.Tasks;

public class BattleManager : MonoBehaviour, IAsyncSceneLoader
{
    public static BattleManager Instance { get; private set; }
    [SerializeField] private BattleConfig config;
    [SerializeField] private CinemachineTargetGroup cinemachineTargetGroup;
    [SerializeField] private BattleComponentIndicatorTarget battleComponentIndicatorTarget;
    [SerializeField] private Transform parentTileMap;
    [SerializeField] private Transform parentProtectObstacle;
    [SerializeField] private Transform parentBarrier;
    [SerializeField] private Transform parentCharacter;
    private bool isInitialized = false;

    public Battle Battle;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        Battle?.Dispose();
    }

    private void Update() 
    {
        if (!isInitialized) return;
        Battle.UpdateInternal();
    }

    public async Task LoadAsync()
    {
        config.Initialize();
        Battle = new Battle(
            config, 
            cinemachineTargetGroup, 
            battleComponentIndicatorTarget, 
            parentTileMap, 
            parentProtectObstacle, 
            parentBarrier, 
            parentCharacter);
        await Battle.BattleComponentField.LoadAsync();
        await Battle.BattleComponentCharacter.LoadAsync();
        Battle.BattleComponentTarget.Initialize();
        // characters etc

        isInitialized = true;
    }

    // Instantiate
    public Object InstantiateGameObject(Object prefab) => Instantiate(prefab);
    public Object InstantiateGameObject(Object prefab, Transform parent) => Instantiate(prefab, parent);
    public Object InstantiateGameObject(Object prefab, Vector3 pos, Quaternion rot) => Instantiate(prefab, pos, rot);
    public Object InstantiateGameObject(Object prefab, Vector3 pos, Quaternion rot, Transform parent) => Instantiate(prefab, pos, rot, parent);
    public void DestroyGameObject(Object go, float time = 0.0f) => Destroy(go, time);
}
