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
}
