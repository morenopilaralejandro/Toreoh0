using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }

    [SerializeField] private CharacterConfig config;    

    public CharacterManagerComponentStorage CharacterManagerComponentStorage;
    public CharacterManagerComponentPersistence CharacterManagerComponentPersistence;

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
        CharacterManagerComponentPersistence?.Unsubscribe();
    }

    private void Initialize()
    {
        CharacterManagerComponentStorage = new CharacterManagerComponentStorage(config);
        CharacterManagerComponentPersistence.Subscribe();
    }
}
