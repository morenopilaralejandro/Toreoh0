using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using Aremoreno.Enums.Localization;

public class LocalizationComponentUISprite : LocalizationComponentUI 
{
    [SerializeField] private LocalizeSpriteEvent localizeSpriteEvent;

    protected override void ApplyLocalizationStyle(LocalizationStyle style)
    {
        if (dictReferenceSprite.TryGetValue(style, out var localizedSprite))
            localizeSpriteEvent.AssetReference = localizedSprite;
    }
}
