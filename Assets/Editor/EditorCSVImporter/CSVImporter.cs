using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Aremoreno.Enums.CSVImporter;

public class CSVImporter : EditorWindow
{
    private CSVImporterConfig config;
    private CSVImporterData data;

    [MenuItem("Tools/CSV/Importer")]
    public static void ShowWindow()
    {
        GetWindow<CSVImporter>("CSVImporter");
    }

    public void OnGUI() 
    {
        GUILayout.Label("CSV Importer", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        config = (CSVImporterConfig)EditorGUILayout.ObjectField(
            "CSVImporterConfig",
            config,
            typeof(CSVImporterConfig),
            false        
        );
        data = (CSVImporterData)EditorGUILayout.ObjectField(
            "CSVImporterData",
            data,
            typeof(CSVImporterData),
            false        
        );
        EditorGUILayout.Space();
        if(GUILayout.Button("Import", GUILayout.Height(40)))
        {
            if(config != null && data != null) 
            {
                CSVImporterParser.Initialize(config);
                ImportCSVFromData();
            }
        }
    }

    public void ImportCSVFromData()
    {
        EditorUtils.CreateFolderFromPath(data.OutputFolder);
        
        Type parserType = typeof(CSVImporterParser);
        Type scriptableObjectType = Type.GetType(data.ScriptableObjectTypeName);
        string csvAbsolutePath = EditorUtils.GetAbsolutePath($"{config.PathCSV}/{data.CSVFileName}");
        string[] lines = File.ReadAllLines(csvAbsolutePath);
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
                object valueParsed = ParseValue(valueRaw, fieldMapping, parserType);
                FieldInfo field = scriptableObjectType.GetField(fieldMapping.FieldName);
                field.SetValue(instance, valueParsed);
            }            
            FieldInfo idField = scriptableObjectType.GetField(data.IdFieldName);
            object idObjectValue = idField.GetValue(instance);
            string idStringValue = idObjectValue.ToString();
            string assetName = $"{data.AssetNamePrefix}{idStringValue}";
            string assetPath = $"{data.OutputFolder}/{assetName}.asset";
            EditorUtils.CreateAsset(instance, assetPath);
            EditorUtils.ConfigureAssetAsAddressable(
                EditorUtils.GetAssetGuid(assetPath), 
                EditorUtils.GetAddressableGroupByGuid(data.AddressableGroup), 
                data.AddressableLabels);
        }
        EditorUtils.SaveAssets();
        EditorUtils.RefreshAssets();
    }

    private object ParseValue(string stringValue, CSVFieldMapping fieldMapping, Type parserType) 
    {
        MethodInfo method = parserType.GetMethod($"{config.MethodPrefix}{fieldMapping.SerializableFieldCustom.ToString()}");
        if (fieldMapping.EnumGenericType != EnumGenericType.None) 
        {
            Type genericType = Type.GetType($"{config.EnumNameSpace}{fieldMapping.EnumGenericType.ToString()}");
            method = method.MakeGenericMethod(genericType);
        }
        return method.Invoke(null, new object [] { stringValue });
    }
}
