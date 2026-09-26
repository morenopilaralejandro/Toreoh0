using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }

    [SerializeField] private DialogConfig config;
    private DialogGameDataProvider gameDataProvider;
    private DialogLocalizationBridge localizationBridge;

    public DialogViewedTracker ViewedTracker { get; private set; }
    public DialogManagerPersistence PersistenceComponent { get; private set; }
    public DialogManagerInkStory InkStoryComponent { get; private set; }
    public DialogCacheSpeaker CacheSpeaker { get; private set; }

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

    private void Start() 
    {
        Initialize();
    }

    private void Initialize() 
    {
        PersistenceComponent = new DialogManagerPersistence(this);
        PersistenceComponent.Subscribe();

        CacheSpeaker = new DialogCacheSpeaker();
        CacheSpeaker.Initialize(config);

        gameDataProvider = new DialogGameDataProvider();
        localizationBridge = new DialogLocalizationBridge();

        InkStoryComponent = new DialogManagerInkStory();
        InkStoryComponent.Initialize(config, gameDataProvider, localizationBridge, CacheSpeaker);
        InkStoryComponent.Subscribe();
    }

    private void OnDestroy() 
    {
        PersistenceComponent?.Unsubscribe();
        InkStoryComponent?.Unsubscribe();
    }
}
