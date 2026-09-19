using UnityEngine;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using System.IO;
using System.Collections.Generic;

public static class EditorUtils 
{
    // folder
    public static void CreateFolder(string parent, string folder)
    {
        if(IsValidFolder($"{parent}/{folder}")) return;
        AssetDatabase.CreateFolder(parent, folder);
    }

    public static void CreateFolderFromPath(string path) 
    {
        string[] parts = path.Split('/');
        string currentPath = parts[0];
        for(int i = 1; i < parts.Length; i++)
        {
            string nextPath = $"{currentPath}/{parts[i]}";
            if (!IsValidFolder(nextPath))
                CreateFolder(currentPath, parts[i]);
            currentPath = nextPath;
        }
    }

    public static string GetAbsolutePath(string path) => Path.Combine(Application.dataPath, path);
    public static string GetAbsolutePathPersistent(string path) => Path.Combine(Application.persistentDataPath, path);
    public static void CreateAsset(Object asset, string path) => AssetDatabase.CreateAsset(asset, path);
    public static void SaveAssets() => AssetDatabase.SaveAssets();
    public static void RefreshAssets() => AssetDatabase.Refresh();
    public static bool IsValidFolder(string path) => AssetDatabase.IsValidFolder(path);

    //asset
    public static bool IsExistingAssetPath(string path) => GetMainAssetTypeAtPath(path) != null;
    public static T LoadAssetAtPath<T>(string path) where T : Object => AssetDatabase.LoadAssetAtPath<T>(path);
    public static string GetAssetGuid(string path) => AssetDatabase.AssetPathToGUID(path);
    public static string GetAssetPath(string guid) => AssetDatabase.GUIDToAssetPath(guid);
    public static System.Type GetMainAssetTypeAtPath(string path) => AssetDatabase.GetMainAssetTypeAtPath(path);

    //addresable
    public static AddressableAssetSettings GetAddressableSettings() => AddressableAssetSettingsDefaultObject.Settings;
    public static AddressableAssetEntry GetAssetEntry(string guid) => GetAddressableSettings().FindAssetEntry(guid);
    public static AddressableAssetGroup GetAssetAddressableGroup(string guid) => GetAssetEntry(guid).parentGroup;
    public static void MarkAsAddressable(string guid) => GetAddressableSettings().CreateOrMoveEntry(guid, null);
    public static List<AddressableAssetGroup> GetAllAddressableGroups() => GetAddressableSettings().groups;
    public static AddressableAssetGroup GetAddressableGroupByName(string groupName) => GetAddressableSettings().FindGroup(groupName);
    public static AddressableAssetGroup GetAddressableGroupByGuid(string guid)
    {
        foreach(AddressableAssetGroup group in GetAllAddressableGroups()) 
        {
            if(group.Guid == guid)
                return group;
        }
        return null;
    }
    public static bool IsExistingAddressableGroupName(string groupName) => GetAddressableGroupByName(groupName) != null;
    public static bool IsExistingAddressableGroupGuid(string groupName) => GetAddressableGroupByGuid(groupName) != null;
    public static void CreateAddressableGroup(string groupName) 
    {
        if (IsExistingAddressableGroupName(groupName)) return;
        GetAddressableSettings().CreateGroup(
            groupName, 
            false, 
            false, 
            true, 
            null, 
            typeof(BundledAssetGroupSchema), 
            typeof(ContentUpdateGroupSchema));
    }
    public static void AssignAssetToAddressableGroup(string assetGuid, AddressableAssetGroup group) => GetAddressableSettings().CreateOrMoveEntry(assetGuid, group);
    public static List<string> GetAllAddressableLabels() => GetAddressableSettings().GetLabels();
    public static void CreateAddressableLabel(string label) => GetAddressableSettings().AddLabel(label, false);
    public static void AssignAssetToAddressableLabel(string guid, string label) => GetAssetEntry(guid).SetLabel(label, true, true);
    public static void AssignAssetToAddressableLabels(string guid, List<string> labels)
    {
        foreach(string label in labels) 
        {
            CreateAddressableLabel(label);
            AssignAssetToAddressableLabel(guid, label);
        }        
    }
    public static void ConfigureAssetAsAddressable(string assetGuid, AddressableAssetGroup group, List<string> labels)
    {
        AssignAssetToAddressableGroup(assetGuid, group);
        AssignAssetToAddressableLabels(assetGuid, labels);
    }
}
