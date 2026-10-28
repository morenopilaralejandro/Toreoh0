using System.Text;

public static class AddressableBuilder 
{
    private static AddressableConfig config;
    private static StringBuilder sb = new StringBuilder();

    public static void Initialize(AddressableConfig addressableConfig) 
    {
        config = addressableConfig;
    }

    private static string BuildAddress(string pathBase, params string[] pathParameters)
    {
        sb.Clear();
        sb.Append(pathBase);
        foreach (string path in pathParameters) 
        {
            sb.Append(config.SeparatorPathMain);
            sb.Append(path);
        }
        return sb.ToString();
    }

    public static string GetCharacterPortraitAddress(string id) =>
        BuildAddress(config.PathCharacterPortrait, id);

    public static string GetItemIconAddress(string id) =>
        BuildAddress(config.PathItemIcon, id);

    public static string GetProtectObstacleSpriteAddress(string id, string state) =>
        BuildAddress(config.PathProtectObstacleSprite, id, state);

    public static string GetFieldTileMapAddress(string id) =>
        BuildAddress(config.PathFieldTileMap, id);
}
