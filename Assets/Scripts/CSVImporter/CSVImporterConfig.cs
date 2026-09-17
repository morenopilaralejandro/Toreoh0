using System.Collections.Generic

[CreateAssetMenu(fileName = "CSVImporterConfig", menuName = "ScriptableObject/CSV/CSVImporterConfig")]
public class CSVImporterConfig : ScriptableObject
{
    [Header("CSV Separator")]
    public char Separator;

    [Header("CSV Path")]
    public string PathCSV;

    [Header("Parse Delimiter")]
    public char DelimiterMain;
    public char DelimiterSub;

    [Header("Parse Delimiter")]
    public int DefaultValueInt;
    public float DefaultValueFloat;

    [Header("Parse Valid Values")]
    public List<string> ValidBoolValues;

    [Header("TypeMapping")]
    public string EnumNameSpace;
    public string MethodPrefix;
    public List<CSVTypeMappingString> CSVTypeMappings;
    public Dictionary<SerializableFieldCustom, CSVTypeMapping> MethodMap;

    public void BuildMethodMap() 
    {
        TypeMap = new Dictionary<SerializableFieldCustom, CSVTypeMapping>();
        var Type parserType = typeof(CSVImporterParser);
        var Type method = parserType.GetMethod($"{MethodPrefix}{mapping.MethodName}");
        var Type genericType = string.IsNullOrWhiteSpace(mapping.GenericTypeName) 
            ? null 
            : GetTypeByName($"{EnumNameSpace}{mapping.GenericTypeName}");
        if (genericType != null)
            method = method.MakeGenericMethod(genericType);
        foreach (mapping in CSVTypeMappings) 
        {
            var newMapping = new CSVTypeMapping 
            {
                SerializableFieldCustom = mapping.SerializableFieldCustom,
                Method = method,
                GenericType = string.IsNullOrWhiteSpace(mapping.GenericTypeName) ? null : mapping.GenericTypeName;
            }
        }
    }
}
