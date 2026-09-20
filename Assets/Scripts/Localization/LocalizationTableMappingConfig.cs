using UnityEngine;
using UnityEngine.Localization.Tables;
using System.Collections.Generic;
using Aremoreno.Enums.Localization;

[CreateAssetMenu(fileName = "LocalizationTableMappingConfig", menuName = "ScriptableObject/Localization/LocalizationTableMappingConfig")]
public class LocalizationTableMappingConfig : ScriptableObject
{
    public List<LocalizationTableMapping> Mappings = new();

    private Dictionary<(LocalizationEntity, LocalizationField, LocalizationStyle), TableReference> dict;

    public void Initialize()
    {
        dict = new ();
        foreach (var mapping in Mappings)
        {
            var key = (mapping.Entity, mapping.Field, mapping.Style);
            dict[key] = mapping.TableReference;
        }
    }

    public TableReference GetTableReference(LocalizationEntity entity, LocalizationField field, LocalizationStyle style)
    {
        var key = (entity, field, style);
        return dict[key];
    }
}
