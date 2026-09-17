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
        get the config (the scriptableObject is called ) CSVImporterConfig get it auto
        get the data that you want (CSVImporterData)

    
    public void Import()
    {
        string csvPath = Path.Combine(Application.dataPath, config.PathCSV, data.FileNameCSV);
        AssetDatabaseManager.CreateFolderFromPath(data.PathOutput);
        
        Type parserType = typeof(CSVImporterParser);
        Type scriptableObjectType = GetTypeByName(data.ScriptableObjectTypeName);
        string[] lines = File.ReadAllLines(csvPath);
        string[] headers = lines[0].Split(config.Separator);
        var columnMap = new Dictionary<string, int>();
        for (int i = 0; i < headers.Length; i++)
            columnMap[headers[i].Trim()] = i;

        for (int i = 1; i < lines.Length; i++) 
        {
            string[] values = lines[i].Split(config.Separator);
            var instance = ScriptableObject.CreateInstance(scriptableObjectType);
            foreach (var fieldMapping in data.FieldMappings) 
            {
                int columnIndex = columnMap[fieldMapping.ColumnName];
                string valueRaw = values[columnIndex].Trim();
                object valueParsed = ParseValue(rawValue, fieldMapping, parserType);
                FieldInfo field = scriptableObjectType.GetField(fieldMapping.FieldName);
                field.SetValue(instance, valueParsed);
            }            
            FieldInfo idField = scriptableObjectType.GetField(data.IdFieldName);
            object idObjectValue = idField.GetValue(instance);
            string idStringValue = idObjectValue.ToString();
            string assetName = $"{data.AssetNamePrefix}{idStringValue}";
            string assetPath = $"{data.PathOutput}/{assetName}.asset";
            AssetDatabase.CreateAsset(instance, assetPath);
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private static object ParseValue(string stringValue, CSVFieldMapping fieldMapping, Type parserType) 
    {
        MethodInfo method = parserType.GetMethod($"{config.MethodPrefix}{fieldMapping.SerializableFieldCustom.ToString()}");
        if (fieldMapping.EnumGenericType != EnumGenericType.None) 
        {
            Type genericType = GetTypeByName($"{config.EnumNameSpace}{fieldMapping.EnumGenericType.ToString()}");
            method = method.MakeGenericMethod(genericType);
        }

        return method.Invoke(null, new object [] { stringValue });
    }
}
