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
        Initialize();
        // obstacles
        // characters etc
    }

    // Instantiate

    public void InstantiateGameObject(Object prefab) => Instantiate(prefab);
    public void InstantiateGameObject(Object prefab, Transform parent) => Instantiate(prefab, parent);
    public void InstantiateGameObject(Object prefab, Vector3 pos, Quaternion rot) => Instantiate(prefab, pos, rot);
    public void InstantiateGameObject(Object prefab, Vector3 pos, Quaternion rot, Transform parent) => Instantiate(prefab, pos, rot, parent);
    public void DestroyGameObject(Object go, float time = 0.0f) => Destroy(go, time);
    
}
