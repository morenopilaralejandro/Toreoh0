using Aremoreno.Enums.Battle;

public class FieldComponentAppearance
{
    public string AddressFieldTileMap;

    public FieldComponentAppearance(FieldData data) 
    {
        AddressFieldTileMap = AddressableBuilder.GetFieldTileMapAddress(data.FieldId.ToString());
    }
}
