using UnityEngine;
using System.Threading.Tasks;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance { get; private set; }
    public DatabaseRegistry DatabaseRegistry = new DatabaseRegistry();

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

    // Async

    public async Task InitializeAsync() 
    {
        CustomLog.Trace($"[DatabaseManager] [InitializeAsync] Start");

        DatabaseDependencies databaseDependencies = new DatabaseDependencies();

        /*
            TeamData depends on other
            databaseDependencies.Register(DatabaseRegistry.TeamData,
                DatabaseRegistry.FormationData,
                DatabaseRegistry.CharacterData)
        */

        await new DatabaseLoader(DatabaseRegistry, databaseDependencies).LoadAsync();

        CustomLog.Trace($"[DatabaseManager] [InitializeAsync] End");
    }

    // API
    // public CharacterData GetCharacterData(string id) => DatabaseRegistry.CharacterData.Get(id);

}
