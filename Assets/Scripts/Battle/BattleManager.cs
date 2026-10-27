using UnityEngine;
using System.Threading.Tasks;

public class BattleManager : MonoBehaviour, IAsyncSceneLoader
{
    public static BattleManager Instance { get; private set; }
    [SerializeField] private BattleConfig config;

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

    public void Initialize() 
    {

    }

    public async Task LoadAsync() 
    {
        config.Initialize();
        Initialize();
        // obstacles
        // characters etc
    }

    // Instantiate

    public Object InstantiateGameObject(Object prefab) => Instantiate(prefab);
    public Object InstantiateGameObject(Object prefab, Transform parent) => Instantiate(prefab, parent);
    public Object InstantiateGameObject(Object prefab, Vector3 pos, Quaternion rot) => Instantiate(prefab, pos, rot);
    public Object InstantiateGameObject(Object prefab, Vector3 pos, Quaternion rot, Transform parent) => Instantiate(prefab, pos, rot, parent);
    public void DestroyGameObject(Object go, float time = 0.0f) => Destroy(go, time);
    
}
