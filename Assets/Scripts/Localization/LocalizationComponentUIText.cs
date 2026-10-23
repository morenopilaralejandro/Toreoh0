using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using Aremoreno.Enums.Localization;

public class LocalizationComponentUIText : LocalizationComponentUI 
{
    [SerializeField] private LocalizeStringEvent localizeStringEvent;

    protected override void ApplyLocalizationStyle(LocalizationStyle style)
    {
        if (dictReferenceString.TryGetValue(style, out var localizedString))
            localizeStringEvent.StringReference = localizedString;
    }
}
