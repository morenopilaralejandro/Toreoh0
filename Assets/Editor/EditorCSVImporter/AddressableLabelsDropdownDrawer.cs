using UnityEngine;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using System.Collections.Generic;
using System.Linq;

[CustomPropertyDrawer(typeof(AddressableLabelsDropdownAttribute))]
public class AddressableLabelsDropdownDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        Rect buttonRect = new Rect(
            position.x,
            position.y,
            position.width,
            EditorGUIUtility.singleLineHeight
        );
        string summary = GetSelectedLabelsSummary(property);
        if(EditorGUI.DropdownButton(
            buttonRect,
            new GUIContent($"{label.text}: {summary}"),
            FocusType.Keyboard
        )) 
        {
            ShowLabelsMenu(property);
        }

        EditorGUI.EndProperty();
    }

    private string GetSelectedLabelsSummary(SerializedProperty property)
    {
        if(property.arraySize == 0) return "None";
        List<string> labels = new();
        for (int i = 0; i < property.arraySize; i++)
            labels.Add(property.GetArrayElementAtIndex(i).stringValue);
        return string.Join(", ", labels);
    }

    private void ShowLabelsMenu(SerializedProperty property) 
    {
        List<string> availableLabels = EditorUtils.GetAllAddressableLabels();
        GenericMenu menu = new GenericMenu();
        List<string> selectedLabels = new();
        for (int i = 0; i < property.arraySize; i++)
            selectedLabels.Add(property.GetArrayElementAtIndex(i).stringValue);
        foreach (string label in availableLabels.OrderBy(x => x)) 
            menu.AddItem(
                new GUIContent(label),
                selectedLabels.Contains(label),
                () => { ToggleLabel(property, label); }
            );
        if (availableLabels.Count == 0)
            menu.AddDisabledItem(new GUIContent("No labels found"));   
        menu.ShowAsContext();
    }

    private void ToggleLabel(SerializedProperty property, string label)
    {
        property.serializedObject.Update();
        int index = FindLableIndex(property, label);
        if (index >= 0) 
        {
            property.DeleteArrayElementAtIndex(index);
        } 
        else 
        {
            int newIndex = property.arraySize;
            property.arraySize++;
            property.InsertArrayElementAtIndex(newIndex);
            property.GetArrayElementAtIndex(newIndex).stringValue = label;
        }
        property.serializedObject.ApplyModifiedProperties();
        GUI.changed = true;
    }

    private int FindLableIndex(SerializedProperty property, string label)
    {
        for (int i = 0; i < property.arraySize; i++)
        {
            if(property.GetArrayElementAtIndex(i).stringValue == label)
                return i;
        }
        return -1;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => 
        EditorGUIUtility.singleLineHeight;
}
