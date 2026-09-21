using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Localization;

[CreateAssetMenu(fileName = "LocalizationConfig", menuName = "ScriptableObject/Localization/LocalizationConfig")]
public class LocalizationConfig : ScriptableObject
{
    [Header("Localization")]
    public bool IsLocalizationEnabled;
    public int LocaleIndexDefault = 0;

    [Header("TableMapping")]
    public char TableNameSeparator;

    [Header("FontAtlas")]
    public string FontAtlasPath;
    public string FontAtlasFileName;
    public List<char> ExtraAtlasCharacters;


}
