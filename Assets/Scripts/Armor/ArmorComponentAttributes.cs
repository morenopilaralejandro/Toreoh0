using Aremoreno.Enums.Battle;

public class ArmorComponentAttributes
{
    public string ArmorId;
    public string ArmorGuid;

    public ArmorComponentAttributes(ArmorData data) 
    {
        ArmorId = data.ArmorId;
        ArmorGuid = data.ArmorId;
    }
}
