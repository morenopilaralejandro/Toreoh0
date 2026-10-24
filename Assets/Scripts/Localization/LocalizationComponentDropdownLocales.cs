using UnityEngine;
using UnityEngine.Localization.Settings;
using System.Collections.Generic;
using TMPro;

public class LocalizationComponentDropdownLocales : MonoBehaviour 
{
    [SerializeField] private TMP_Dropdown dropdown;

    private void ApplyLocalization()
    {
        dropdown.ClearOptions();
        List<string> options = new List<string>();

        foreach(var locale in LocalizationSettings.AvailableLocales.Locales)
            options.Add(locale.Identifier.CultureInfo.NativeName);

        dropdown.AddOptions(options);
        dropdown.RefreshShownValue();
    }

    private void OnEnable() 
    {
        ApplyLocalization();
    }

}
