public class CapturePortal 
{
    public CapturePortalComponentAttributes AttributesComponent;
    public CapturePortalComponentAppearance AppearanceComponent;

    public CapturePortal(CapturePortalData data)
    {
        AttributesComponent = new CapturePortalComponentAttributes(data);
        AppearanceComponent = new CapturePortalComponentAppearance(data);
    }
}
