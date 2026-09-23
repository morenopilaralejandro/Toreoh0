public static class PersistenceValidator
{
    private static PersistenceConfig config;

    public static void Initialize(PersistenceConfig persistenceConfig)
    {
        config = persistenceConfig;
    }

    public static bool IsValidSaveData(SaveData saveData) 
    {
        // TODO check SaveFormatVersion etc
        return data != null;
    }
}
