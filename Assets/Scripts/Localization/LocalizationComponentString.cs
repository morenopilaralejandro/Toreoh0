using System.Collections.Generic;
using UnityEngine.Localization;
using Aremoreno.Enums.Localization;

public class LocalizationComponentString
{
    private Dictionary<LocalizationField, LocalizedString> localizedStrings = new ();

    public LocalizationComponentString(LocalizationEntity entity, string id, LocalizationField[] fields)
    {
        Initialize(entity, id, fields);
    }

    public void Initialize(LocalizationEntity entity, string id, LocalizationField[] fields)
    {
        localizedStrings.Clear();
        foreach (var field in fields)
            localizedStrings[field] = new LocalizedString(
                LocalizationManager.Instance.GetTableReference(entity, field), 
                id
            );
    }

    public string GetString(LocalizationField field) => localizedStrings[field].GetLocalizedString();
    public void SetArguments(LocalizationField field, object args) => localizedStrings[field].Arguments = new object[] { args };
}
