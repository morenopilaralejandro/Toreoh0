using UnityEngine.Localization.Tables;
using Aremoreno.Enums.Localization;

[System.Serializable]
public struct LocalizationTableMapping
{
    public LocalizationEntity Entity;
    public LocalizationField Field;
    public LocalizationStyle Style;
    public TableReference TableReference;
}
