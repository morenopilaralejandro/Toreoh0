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
        if(EditorGUI.DropdownButton(
            position,
            new GUIContent($"{label.text}: {GetSelectedLabelsSummary(property)}"),
            FocusType.Keyboard
        )) 
        {
            ShowLabelsMenu(property);
        }
        EditorGUI.EndProperty();
    }

    private string GetSelectedLabelsSummary(SerializedProperty property)
    {
        SerializedProperty labels = property.FindPropertyRelative("LabelList");
        List<string> selectedLabels = new();
        for (int i = 0; i < labels.arraySize; i++)
            selectedLabels.Add(labels.GetArrayElementAtIndex(i).stringValue);
        if(selectedLabels.Count == 0) return "None";
        return string.Join(", ", selectedLabels);
    }

    private void ShowLabelsMenu(SerializedProperty property) 
    {
        List<string> availableLabels = EditorUtils.GetAllAddressableLabels();
        GenericMenu menu = new GenericMenu();
        SerializedObject serializedObject = property.serializedObject;
        string propertyPath = property.propertyPath;
        SerializedProperty labels = property.FindPropertyRelative("LabelList");
        List<string> selectedLabels = new();
        for (int i = 0; i < labels.arraySize; i++)
            selectedLabels.Add(labels.GetArrayElementAtIndex(i).stringValue);
        foreach (string label in availableLabels.OrderBy(x => x)) 
            menu.AddItem(
                new GUIContent(label),
                selectedLabels.Contains(label),
                () => 
                { 
                    serializedObject.Update();
                    SerializedProperty parent = serializedObject.FindProperty(propertyPath);
                    SerializedProperty labelsProperty = parent.FindPropertyRelative("LabelList");
                    ToggleLabel(labelsProperty, label); 
                    serializedObject.ApplyModifiedProperties();
                }
            );
        if (availableLabels.Count == 0)
            menu.AddDisabledItem(new GUIContent("No labels found"));   
        menu.ShowAsContext();
    }

    private void ToggleLabel(SerializedProperty property, string label)
    {
        int index = FindLableIndex(property, label);
        if (index >= 0) 
        {
            property.DeleteArrayElementAtIndex(index);
            return;
        } 
        int newIndex = property.arraySize;
        property.InsertArrayElementAtIndex(newIndex);
        SerializedProperty element = property.GetArrayElementAtIndex(newIndex);
        element.stringValue = label;
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
