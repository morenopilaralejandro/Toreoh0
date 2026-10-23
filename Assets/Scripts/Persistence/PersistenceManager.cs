using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance { get; private set; }

    [SerializeField] private PersistenceConfig config;
    public PlayTimeTracker PlayTimeTracker;
    public PersistenceManagerComponentSaveSlots SaveSlotsComponent;
    public PersistenceManagerComponentAutoSave AutoSaveComponent;

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

        SaveSlotsComponent = new PersistenceManagerComponentSaveSlots(config);
        AutoSaveComponent = new PersistenceManagerComponentAutoSave(SaveSlotsComponent.SaveSlots[0]);
    }
}
