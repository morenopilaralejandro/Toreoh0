using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Localization;

[CreateAssetMenu(fileName = "LocalizationConfig", menuName = "ScriptableObject/Localization/LocalizationConfig")]
public class LocalizationConfig : ScriptableObject
{
    [Header("FontAtlas")]
    public string FontAtlasPath;
    public string FontAtlasFileName;
    public List<char> ExtraAtlasCharacters;

    [Header("TableMapping")]
    public char TableNameSeparator;
}
