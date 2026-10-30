public class Wing 
{
    public WingComponentAttributes WingComponentAttributes;
    public WingComponentPersistence WingComponentPersistence;

    public Wing(WingData data)
    {
        WingComponentAttributes = new WingComponentAttributes(data);
        WingComponentPersistence = new WingComponentPersistence(this);
    }
}
