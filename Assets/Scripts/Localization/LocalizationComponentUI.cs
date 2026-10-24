using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using System.Collections.Generic;
using Aremoreno.Enums.Localization;

public abstract class LocalizationComponentUI : MonoBehaviour 
{
    [SerializeField] protected List<LocalizationReferenceStyleMapping> listMappingReference;
    protected Dictionary<LocalizationStyle, LocalizedString> dictReferenceString = new ();
    protected Dictionary<LocalizationStyle, LocalizedSprite> dictReferenceSprite = new ();

    protected void BuildDict()
    {
        dictReferenceString.Clear();
        dictReferenceSprite.Clear();
        foreach(var mapping in listMappingReference) 
        {
            dictReferenceString[mapping.Style] = mapping.LocalizedString;
            dictReferenceSprite[mapping.Style] = mapping.LocalizedSprite;
        }
    }

    public void SetData(List<LocalizationReferenceStyleMapping> listMappingReference) 
    {
        this.listMappingReference = listMappingReference;
        BuildDict();
        ApplyCurrentStyle();
    }

    protected abstract void ApplyLocalizationStyle(LocalizationStyle style);
    protected void ApplyCurrentStyle() 
    {
        if (SettingsManager.Instance == null || SettingsManager.Instance.Settings.Common == null) return;
        ApplyLocalizationStyle(SettingsManager.Instance.Settings.Common.LocalizationStyle);
    }

    // event
    protected virtual void OnEnable() 
    {
        BuildDict();
        ApplyCurrentStyle();
        SettingsEvents.OnLocalizationStyleChanged += OnLocalizationStyleChanged;
    }

    protected virtual void OnDisable() 
    {
        SettingsEvents.OnLocalizationStyleChanged -= OnLocalizationStyleChanged;
    }

    protected virtual void OnLocalizationStyleChanged(LocalizationStyle style)
    {
        ApplyLocalizationStyle(style);
    }
}
