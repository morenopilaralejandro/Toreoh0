using UnityEngine;
using UnityEditor;
using UnityEditor.Localization;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class LocalizationFontAtlasGenerator : EditorWindow
{
    private LocalizationConfig config;

    [MenuItem("Tools/Localization/FontAtlasGenerator")]
    public static void ShowWindow()
    {
        GetWindow<LocalizationFontAtlasGenerator>("LocalizationFontAtlasGenerator");
    }

    public void OnGUI() 
    {
        GUILayout.Label("LocalizationFontAtlasGenerator", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        config = (LocalizationConfig)EditorGUILayout.ObjectField(
            "LocalizationConfig",
            config,
            typeof(LocalizationConfig),
            false        
        );
        EditorGUILayout.Space();
        if(GUILayout.Button("Generate", GUILayout.Height(40)))
        {
            if(config != null) 
                Generate();
        }
    }

    public void Generate()
    {
        EditorUtils.CreateFolderFromPath(config.FontAtlasPath);
        var characters = new HashSet<char>();
        foreach (string guid in EditorUtils.FindAssets("t:StringTableCollection"))
        {
            string path = EditorUtils.GetAssetPath(guid);
            var collection = EditorUtils.LoadAssetAtPath<StringTableCollection>(path);
            foreach (var table in collection.StringTables) 
            {
                foreach (var entry in table.Values) 
                {
                    if (string.IsNullOrEmpty(entry.LocalizedValue)) continue;
                    foreach (var c in entry.LocalizedValue)
                        characters.Add(c);
                }
            }
        }

        foreach (var c in config.ExtraAtlasCharacters) 
            characters.Add(c);

        var shortedCharacters = characters.ToList();
        shortedCharacters.Sort();
        File.WriteAllText($"{config.FontAtlasPath}/{config.FontAtlasFileName}", new string(shortedCharacters.ToArray()).Normalize(NormalizationForm.FormC));
        EditorUtils.RefreshAssets();
    }
}
