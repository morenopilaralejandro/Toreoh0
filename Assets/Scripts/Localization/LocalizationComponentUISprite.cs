using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using Aremoreno.Enums.Localization;

public class LocalizationComponentUISprite : MonoBehaviour 
{
    [SerializeField] private LocalizeSpriteEvent localizeSpriteEvent;
    [SerializeField] private LocalizedSprite spriteLocalized;
    [SerializeField] private LocalizedSprite spriteRomanized;

    private void ApplyLocalizationStyle(LocalizationStyle style) 
    {
        switch (style)
        {
            case LocalizationStyle.Localized:
                localizeSpriteEvent.AssetReference = spriteLocalized;
                break;
            case LocalizationStyle.Romanized:
                localizeSpriteEvent.AssetReference = spriteRomanized;
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
