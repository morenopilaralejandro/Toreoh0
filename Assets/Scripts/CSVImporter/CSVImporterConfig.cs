using System.Collections.Generic

[CreateAssetMenu(fileName = "CSVImporterConfig", menuName = "ScriptableObject/CSV/CSVImporterConfig")]
public class CSVImporterConfig : ScriptableObject
{
    [Header("CSV Separator")]
    public char Separator;

    [Header("CSV Path")]
    public string PathCSV;
    public string PathData;

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
}
