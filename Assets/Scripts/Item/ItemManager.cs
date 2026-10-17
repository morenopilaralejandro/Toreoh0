using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    [SerializeField] private ItemConfig config;    

    public ItemManagerComponentStorage StorageComponent;
    public ItemManagerComponentCurrency CurrencyComponent;
    public ItemManagerComponentUsage UsageComponent;
    public ItemManagerComponentProcess ProcessComponent;
    public ItemManagerComponentPersistence PersistenceComponent;

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
        StorageComponent = new ItemManagerComponentStorage(config);
        CurrencyComponent = new ItemManagerComponentCurrency(config);
        UsageComponent = new ItemManagerComponentUsage();
        ProcessComponent = new ItemManagerComponentProcess(StorageComponent, CurrencyComponent);
        PersistenceComponent = new ItemManagerComponentPersistence(this);
        PersistenceComponent.Subscribe();
    }
}
