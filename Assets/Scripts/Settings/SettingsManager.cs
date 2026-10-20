using UnityEngine;

public class SettingsManager : MonoBehaviour 
{
    public static SettingsManager Instance { get; private set; }
    
    [SerializeField] private SettingsConfig config;
    public Settings Settings;
    public SettingsManagerComponentSetter SetterComponent;
    public SettingsManagerComponentCopy CopyComponent;
    public SettingsManagerComponentPersistence PersistenceComponent;

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

    public void Start() 
    {
        Initialize();
    }

    public void Initialize() 
    {
        SetterComponent = new SettingsManagerComponentSetter(this);
        CopyComponent = new SettingsManagerComponentCopy(this);
        PersistenceComponent = new SettingsManagerComponentPersistence(this, config);

        PersistenceComponent.Import();
    }
}
