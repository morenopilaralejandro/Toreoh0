using Aremoreno.Enums.Character;
using Aremoreno.Enums.Move;

public class MoveComponentAttributes
{
    public string MoveId;
    public string MoveGuid;
    public Element Element;
    public MoveCategory MoveCategory;
    public MoveCommandType MoveCommandType;
    public int Cost;

    public MoveComponentAttributes(MoveData data) 
    {
        MoveId = data.MoveId;
        MoveGuid = data.MoveId;
        Element = data.Element;
        MoveCategory = data.MoveCategory;
        MoveCommandType = data.MoveCommandType;
        Cost = data.Cost;
    }
}
