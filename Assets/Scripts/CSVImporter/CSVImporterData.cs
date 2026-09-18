using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CSVImporterData", menuName = "ScriptableObject/CSV/CSVImporterData")]
public class CSVImporterData : ScriptableObject
{
    public string CSVFileName;
    public string OutputFolder;
    public string ScriptableObjectTypeName;
    public string AssetNamePrefix;
    public string IdFieldName;
    [AddressableGroupDropdown]
    public string AddressableGroup;
    [AddressableLabelsDropdown]
    public List<string> AddressableLabels;
    public List<CSVFieldMapping> FieldMappings;
}
