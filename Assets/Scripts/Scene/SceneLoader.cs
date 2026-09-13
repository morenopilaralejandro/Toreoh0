public class SceneLoader
{
    public ISceneLoaderRegistry Registry { get; private set; }
    public ISceneLoaderOperations Operations { get; private set; }
    public ISceneLoaderStrategy Strategy;
    public InputManager InputManager { get; private set; }
    public DatabaseManager DatabaseManager { get; private set; }
    
    public SceneLoader(
        ISceneLoaderRegistry registry,
        ISceneLoaderOperations operations,
        InputManager inputManager,
        DatabaseManager databaseManager) 
    {
        Initialize(registry, operations, inputManager, databaseManager);
    }

    private void Initialize(
        ISceneLoaderRegistry registry,
        ISceneLoaderOperations operations,
        InputManager inputManager,
        DatabaseManager databaseManager) 
    {
        Registry = registry;
        Operations = operations;
        InputManager = inputManager;
        DatabaseManager = databaseManager;
    }
}
