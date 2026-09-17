public class CSVImporter
{
    [MenuItem("Tools/CSV/Import")]
    public static void ImportCSV() 
    {
        get the config
        get the data that you want

        ImportFromConfig
    }

    // add gui
        get the config
        get the data that you want

    
    public void Import()
    {
        string csvPath = Path.Combine(Application.dataPath, config.PathCSV, data.FileNameCSV);
        AssetDatabaseManager.CreateFolderFromPath(data.PathOutput);
        
        string[] lines = File.ReadAllLines(csvPath);
        string[] headers = lines[0].Split(config.Separator);
        var columnMap = new Dictionary<string, int>();
        for (int i = 0; i < headers.Length; i++)
            columnMap[headers[i].Trim()] = i;

        for (int i = 1; i < lines.Length; i++) 
        {
            string[] values = lines[i].Split(config.Separator);
            Type scriptableObjectType = GetTypeByName(data.ScriptableObjectTypeName);
            var instance = ScriptableObject.CreateInstance(scriptableObjectType);
            foreach (var fieldMapping in data.FieldMappings) 
            {
                int columnIndex = columnMap[fieldMapping.ColumnName];
                string valueRaw = values[columnIndex].Trim();
                object valueParsed = ParseValue(rawValue, fieldMapping.SerializableFieldCustom);
                FieldInfo field = scriptableObjectType.GetField(fieldMapping.FieldName);
                field.SetValue(instance, valueParsed);
            }            
            FieldInfo idField = scriptableObjectType.GetField(data.IdFieldName);
            object idObjectValue = idField.GetValue(instance);
            string idStringValue = idObjectValue.ToString();
            string assetName = $"{data.AssetNamePrefix}{idValue}";
            string assetPath = $"{data.PathOutput}/{assetName}.asset";
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private static object ParseValue(string stringValue, SerializableFieldCustom serializableFieldCustom) 
    {
        CSVMethodMapping mapping = config.MethodMap[serializableFieldCustom];
        var method = mapping.Method;
        return method.Invoke(null, new object [] { string});
    }
}
