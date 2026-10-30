using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }

    [SerializeField] private WeaponConfig config;    

    public WeaponManagerComponentStorage WeaponManagerComponentStorage;
    public WeaponManagerComponentPersistence WeaponManagerComponentPersistence;

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
        WeaponManagerComponentPersistence?.Unsubscribe();
    }

    private void Initialize()
    {
        WeaponManagerComponentStorage = new WeaponManagerComponentStorage(config);
        WeaponManagerComponentPersistence.Subscribe();
    }
}
