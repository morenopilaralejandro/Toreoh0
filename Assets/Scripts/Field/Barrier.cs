public class Barrier 
{
    public BarrierComponentAttributes AttributesComponent;
    public BarrierComponentAppearance AppearanceComponent;

    public Barrier(BarrierData data) 
    {
        AttributesComponent = new BarrierComponentAttributes(data);
        AppearanceComponent = new BarrierComponentAppearance(data);
    }
}
