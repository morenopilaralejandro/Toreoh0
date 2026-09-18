using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AddressableGroupDropdownAttribute))]
public class AddressableGroupDropdownDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var groups = EditorUtils.GetAllAddressableGroups();
        string[] groupNames = new string[groups.Count + 1];
        string[] groupGuids = new string[groups.Count + 1];
        groupNames[0] = "None";
        groupGuids[0] = "";
        for (int i = 1; i < groups.Count; i++)
        {
            var group = groups[i];
            groupNames[i] = group.Name;
            groupGuids[i] = group.Guid;
        }
        
        int selectedIndex = 0;
        for (int i = 1; i < groupGuids.Length; i++)
        {
            if(groupGuids[i] == property.stringValue) 
            {
                selectedIndex = i;
                break;
            }
        }

        EditorGUI.BeginProperty(position, label, property);
        EditorGUI.BeginChangeCheck();
    
        int newIndex = EditorGUI.Popup(position, label.text, selectedIndex, groupNames);
        if (EditorGUI.EndChangeCheck())
        {
            property.stringValue = groupGuids[newIndex];
        }
    
        EditorGUI.EndProperty();
    }
}
