using Aremoreno.Enums.Move;

public class MoveComponentAttributes
{
    public string MoveId;
    public string MoveGuid;
    public MoveCategory MoveCategory;
    public MoveCommandType MoveCommandType;

    public MoveComponentAttributes(MoveData data) 
    {
        MoveId = data.MoveId;
        MoveGuid = data.MoveId;
        MoveCategory = data.MoveCategory;
        MoveCommandType = data.MoveCommandType;
    }
}
