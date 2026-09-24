using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance { get; private set; }

    [SerializeField] private PersistenceConfig config;
    public SaveSlot[] SaveSlots;
    public PlayTimeTracker PlayTimeTracker;

    private void Awake() 
    {
        if(Instance != null && Instance != this)
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
        PlayTimeTracker?.Unsubscribe();
    }

    private void Initialize() 
    {
        PersistenceValidator.Initialize(config);

        PlayTimeTracker = new PlayTimeTracker();
        PlayTimeTracker.Subscribe();

        SaveSlots = new SaveSlot[config.SaveSlotCount];
        for (int i = 0; i < SaveSlots.Length; i++)
            SaveSlots[i] = new SaveSlot(i, config);
    }
}
