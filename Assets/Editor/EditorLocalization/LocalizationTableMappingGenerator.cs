using UnityEngine;
using UnityEditor;
using UnityEditor.Localization;
using Aremoreno.Enums.Localization;

public class LocalizationTableMappingGenerator : EditorWindow
{
    private LocalizationConfig config;
    private LocalizationTableMappingConfig mappingConfig;

    [MenuItem("Tools/Localization/LocalizationTableMappingGenerator")]
    public static void ShowWindow()
    {
        GetWindow<LocalizationTableMappingGenerator>("LocalizationTableMappingGenerator");
    }

    public void OnGUI() 
    {
        GUILayout.Label("LocalizationTableMappingGenerator", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        config = (LocalizationConfig)EditorGUILayout.ObjectField(
            "LocalizationConfig",
            config,
            typeof(LocalizationConfig),
            false        
        );
        mappingConfig = (LocalizationTableMappingConfig)EditorGUILayout.ObjectField(
            "LocalizationTableMappingConfig",
            mappingConfig,
            typeof(LocalizationTableMappingConfig),
            false        
        );
        EditorGUILayout.Space();
        if(GUILayout.Button("Generate", GUILayout.Height(40)))
        {
            if(config != null && mappingConfig != null) 
                Generate();
        }
    }

    public void Generate() 
    {
        mappingConfig.Mappings = new ();
        ProcessStringTables();
        ProcessAssetTables();
    }

    private void ProcessStringTables()
    {
        foreach (string guid in EditorUtils.FindAssets("t:StringTableCollection"))
        {
            string path = EditorUtils.GetAssetPath(guid);
            var collections = EditorUtils.LoadAssetAtPath<StringTableCollection>(path);
            if(!TryParseTableName(collections.TableCollectionName, out var mapping)) return;
            mappingConfig.Mappings.Add(mapping);
        }
    }

    private void ProcessAssetTables()
    {
        foreach (string guid in EditorUtils.FindAssets("t:AssetTableCollection"))
        {
            string path = EditorUtils.GetAssetPath(guid);
            var collections = EditorUtils.LoadAssetAtPath<AssetTableCollection>(path);
            if(!TryParseTableName(collections.TableCollectionName, out var mapping)) return;
            mappingConfig.Mappings.Add(mapping);
        }
    }

    private bool TryParseTableName(string tableName, out LocalizationTableMapping mapping) 
    {
        mapping = new LocalizationTableMapping();
        LocalizationEntity entity = default;
        LocalizationField field = default;
        LocalizationStyle style = default;
        string[] parts = tableName.Split(config.TableNameSeparator);
        if (parts.Length < 4 || parts.Length > 6) 
        {
            return false;
        }
        else if (parts.Length == 4)
        {
            bool isValidName = 
                System.Enum.TryParse(parts[1], true, out entity) &&
                System.Enum.TryParse(parts[2], true, out field) &&
                System.Enum.TryParse(parts[3], true, out style);
            if (isValidName) 
            {
                mapping.Entity = entity;
                mapping.Field = field;
                mapping.Style = style;
                mapping.TableReference = tableName;
            }
            return isValidName;
        }
        return false;
    }
}
