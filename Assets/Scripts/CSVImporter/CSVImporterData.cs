using System.Collections.Generic

[CreateAssetMenu(fileName = "CSVImporterData", menuName = "ScriptableObject/CSV/CSVImporterData")]
public class CSVImporterData : ScriptableObject
{
    public string CSVFileName;
    public string OutputFolder;
    public string ScriptableObjectTypeName;
    public string AssetNamePrefix;
    public string IdFieldName;
    public string AddressableGroup;
    public string AddressableTag;
    public List<CSVFieldMapping> FieldMappings;
}
