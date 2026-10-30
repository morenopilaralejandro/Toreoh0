using UnityEngine;

public class WingManager : MonoBehaviour
{
    public static WingManager Instance { get; private set; }

    [SerializeField] private WingConfig config;    

    public WingManagerComponentStorage WingManagerComponentStorage;
    public WingManagerComponentPersistence WingManagerComponentPersistence;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    private void OnDestroy() 
    {
        WingManagerComponentPersistence?.Unsubscribe();
    }

    private void Initialize()
    {
        WingManagerComponentStorage = new WingManagerComponentStorage(config);
        WingManagerComponentPersistence.Subscribe();
    }
}
