using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using Aremoreno.Enums.Localization;

public class LocalizationComponentUIText : MonoBehaviour 
{
    [SerializeField] private LocalizeStringEvent localizeStringEvent;
    [SerializeField] private LocalizedString stringLocalized;
    [SerializeField] private LocalizedString stringRomanized;

    private void ApplyLocalizationStyle(LocalizationStyle style) 
    {
        switch (style)
        {
            case LocalizationStyle.Localized:
                localizeStringEvent.StringReference = stringLocalized;
                break;
            case LocalizationStyle.Romanized:
                localizeStringEvent.StringReference = stringRomanized;
                break;
        }
    }

    // event
    private void OnEnable() 
    {
        SettingsEvents.OnLocalizationStyleChanged += OnLocalizationStyleChanged;
        ApplyLocalizationStyle(LocalizationStyle.Localized); // TODO current
    }

    private void OnDisable() 
    {
        SettingsEvents.OnLocalizationStyleChanged -= OnLocalizationStyleChanged;
    }

    private void OnLocalizationStyleChanged(LocalizationStyle style)
    {
        ApplyLocalizationStyle(style);
    }
}
