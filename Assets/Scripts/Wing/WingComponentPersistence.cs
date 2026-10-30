public class WingComponentPersistence
{
    private Wing Wing;

    public WingComponentPersistence(Wing Wing)
    {
        this.Wing = Wing;
    }

    public WingSaveData Export()
    {
        return null;
        /*
        return new WingSaveData 
        {
            WingManagerComponentStorageSaveData = WingManager.StorageComponent.Export(),
            WingManagerComponentCurrencySaveData = WingManager.CurrencyComponent.Export()
        };
        */
    }
}
