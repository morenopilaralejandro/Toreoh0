using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static TeamManager Instance { get; private set; }

    [SerializeField] private TeamConfig config;    

    public TeamManagerComponentStorage StorageComponent;
    public TeamManagerComponentPersistence PersistenceComponent;

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
        PersistenceComponent?.Unsubscribe();
    }

    private void Initialize()
    {
        StorageComponent = new TeamManagerComponentStorage(config);
        PersistenceComponent.Subscribe();
    }
}
