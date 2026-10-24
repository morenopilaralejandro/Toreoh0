using UnityEngine;
using UnityEngine.Localization;
using System.Collections.Generic;
using TMPro;
using Aremoreno.Enums.Localization;

public class LocalizationComponentDropdown : MonoBehaviour 
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private List<LocalizedString> listLocalizedStringLocalized;
    [SerializeField] private List<LocalizedString> listLocalizedStringRomanized;

    private void ApplyLocalization()
    {
        dropdown.ClearOptions();
        List<string> options = new List<string>(listLocalizedStringLocalized.Count);

        if (SettingsManager.Instance == null) return;
        switch (SettingsManager.Instance.Settings.Common.LocalizationStyle)
        {
            case LocalizationStyle.Localized:
                foreach(var localizedString in listLocalizedStringLocalized)
                    options.Add(localizedString.GetLocalizedString());
                break;
            case LocalizationStyle.Romanized:
                foreach(var localizedString in listLocalizedStringRomanized)
                    options.Add(localizedString.GetLocalizedString());
                break;
        }

        dropdown.AddOptions(options);
        dropdown.RefreshShownValue();
    }

    private void OnEnable() 
    {
        SettingsEvents.OnLanguageChanged += OnLanguageChanged;
        SettingsEvents.OnLocalizationStyleChanged += OnLocalizationStyleChanged;
        ApplyLocalization();
    }

    private void OnDisable() 
    {
        SettingsEvents.OnLanguageChanged -= OnLanguageChanged;
        SettingsEvents.OnLocalizationStyleChanged -= OnLocalizationStyleChanged;
    }

    private void OnLanguageChanged(int localeIndex) => ApplyLocalization();
    private void OnLocalizationStyleChanged(LocalizationStyle style) => ApplyLocalization();
}
