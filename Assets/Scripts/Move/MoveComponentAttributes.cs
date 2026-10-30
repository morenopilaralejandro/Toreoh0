using Aremoreno.Enums.Battle;

public class MoveComponentAttributes
{
    public string MoveId;
    public string MoveGuid;

    public MoveComponentAttributes(MoveData data) 
    {
        MoveId = data.MoveId;
        MoveGuid = data.MoveId;
    }
}
