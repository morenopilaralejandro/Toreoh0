public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }

    [SerializeField] DialogConfig config;
    public DialogViewedTracker ViewedTracker;
    public DialogManagerPersistence PersistenceComponent;
    public DialogManagerInkStory InkStoryComponent;

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

    private void Initialize() 
    {
        PersistenceComponent = new DialogManagerPersistence(this);
        PersistenceComponent.Subscribe();

        InkStoryComponent = new DialogManagerInkStory();
    }

    private void OnDestroy() 
    {
        PersistenceComponent?.Unsubscribe();
    }
}
