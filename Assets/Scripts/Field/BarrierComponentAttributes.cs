using Aremoreno.Enums.Battle;

public class BarrierComponentAttributes
{
    public string BarrierId;
    public BarrierType BarrierType;

    public BarrierComponentAttributes(BarrierData data) 
    {
        BarrierId = data.BarrierId;
        BarrierType = data.BarrierType;
    }
}
