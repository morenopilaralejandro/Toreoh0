public class Barrier 
{
    public BarrierComponentAttributes AttributesComponent;
    public BarrierComponentAppearance AppearanceComponent;
    public BarrierComponentSfx BarrierComponentSfx;

    public Barrier(BarrierData data) 
    {
        AttributesComponent = new BarrierComponentAttributes(data);
        AppearanceComponent = new BarrierComponentAppearance(data);
        BarrierComponentSfx = new BarrierComponentSfx(data);
    }
}
