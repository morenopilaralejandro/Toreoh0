using UnityEngine;

public class ArmorManager : MonoBehaviour
{
    public static ArmorManager Instance { get; private set; }

    [SerializeField] private ArmorConfig config;    

    public ArmorManagerComponentStorage ArmorManagerComponentStorage;
    public ArmorManagerComponentPersistence ArmorManagerComponentPersistence;

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
        ArmorManagerComponentPersistence?.Unsubscribe();
    }

    private void Initialize()
    {
        ArmorManagerComponentStorage = new ArmorManagerComponentStorage(config);
        ArmorManagerComponentPersistence.Subscribe();
    }
}
