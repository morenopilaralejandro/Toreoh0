using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance { get; private set; }

    public StoryManagerComponentPersistence PersistenceComponent { get; private set; }
    public ChestTracker ChestTracker { get; private set; }

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
        PersistenceComponent = new StoryManagerComponentPersistence(this);

        ChestTracker = new ChestTracker();
    }
}
