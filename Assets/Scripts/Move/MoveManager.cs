using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public static MoveManager Instance { get; private set; }

    [SerializeField] private MoveConfig config;    

    public MoveManagerComponentStorage MoveManagerComponentStorage;
    public MoveManagerComponentPersistence MoveManagerComponentPersistence;

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
        MoveManagerComponentPersistence?.Unsubscribe();
    }

    private void Initialize()
    {
        MoveManagerComponentStorage = new MoveManagerComponentStorage(config);
        MoveManagerComponentPersistence.Subscribe();
    }
}
