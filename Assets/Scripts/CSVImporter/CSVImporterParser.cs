using System.Collections.Generic;

public static class CSVImporterParser 
{
    private static CSVImporterConfig config;

    public static void Initialize(CSVImporterConfig importerConfig)
    {
        config = importerConfig;
    }

    // Generic
    public static int ParseInt(string stringValue)
    {
        if(string.IsNullOrWhiteSpace(stringValue)) return config.DefaultValueInt;
        if(int.TryParse(stringValue.Trim(), out int result)) return result;
        return config.DefaultValueInt;
    }

    public static float ParseFloat(string stringValue) => float.Parse(stringValue);

    public static bool ParseBool(string stringValue) 
    {
        foreach(var validValue in config.ValidBoolValues)
            if (stringValue == validValue) return true;
        return false;
    }
    
    public static string ParseString(string stringValue) => stringValue.Trim();

    public static List<string> ParseStringList(string stringValue) 
    {
        var list = new List<string>();
        if(string.IsNullOrWhiteSpace(stringValue)) return list;

        string[] parts = stringValue.Split(config.DelimiterMain);
        foreach (string part in parts) 
            list.Add(part.Trim());
        return list;
    }

    public static T ParseEnum<T>(string stringValue) where T : struct, System.Enum => EnumUtils.StringToEnum<T>(stringValue, ignoreCase : true);
    
    public static List<T> ParseEnumList<T>(string stringValue) where T : struct, System.Enum => EnumUtils.ParseEnumList<T>(stringValue, config.DelimiterMain);

    // Item
    public static List<ItemReward> ParseItemRewardList(string stringValue)
    {
        var list = new List<ItemReward>();
        if(string.IsNullOrWhiteSpace(stringValue)) return list;

        string[] parts = stringValue.Split(config.DelimiterMain);
        foreach (string part in parts)
        {
            string[] subparts = part.Trim().Split(config.DelimiterSub);
            var itemReward = new ItemReward();
            itemReward.ItemId = ParseString(subparts[0]);
            itemReward.Quantity = ParseInt(subparts[1]);
            list.Add(itemReward);
        }
        return list;
    }
}
