using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance { get; private set; }

    [SerializeField] private WorldConfig config;

    public CharacterEntityWorld CharacterMain;
    public WorldZoneLoader ZoneLoader { get; private set; }
    public SpawnPointRegistry SpawnPointRegistry { get; private set; }

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

    }
}
