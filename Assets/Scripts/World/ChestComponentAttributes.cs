using Aremoreno.Enums.World;

public class ChestComponentAttributes
{
    public string ChestId;
    public ChestState DefaultState;
    
    public ChestComponentAttributes(ChestData data) 
    {
        ChestId = data.ChestId;
        DefaultState = data.DefaultState;
    }
}
