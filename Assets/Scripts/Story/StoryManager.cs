using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance { get; private set; }

    public ChestTracker ChestTracker { get; private set; }
    public StorySystemFlags Flags;
    public StoryManagerComponentPersistence PersistenceComponent { get; private set; }

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
        PersistenceComponent?.Unsubscribe();
    }

    private void Initialize() 
    {
        ChestTracker = new ChestTracker();
        Flags = new StorySystemFlags();

        PersistenceComponent = new StoryManagerComponentPersistence(this);
        PersistenceComponent.Subscribe();
    }
}
