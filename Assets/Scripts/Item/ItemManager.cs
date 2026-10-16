using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static DatabaseManager Instance { get; private set; }

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
    }

    private void OnDestroy() 
    {
        PersistenceComponent?.Unsubscribe();
    }

    private void Initialize()
    {
        StorageComponent = new ItemManagerComponentStorage();
        CurrencyComponent = new ItemManagerComponentCurrency();
        UsageComponent = new ItemManagerComponentStorage();
        ProcessComponent = new ItemManagerComponentStorage();
        PersistenceComponent = new ItemManagerComponentStorage(this);
        PersistenceComponent.Subscribe();
    }
}
