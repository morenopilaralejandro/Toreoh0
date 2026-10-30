public class ArmorComponentPersistence
{
    private Armor Armor;

    public ArmorComponentPersistence(Armor Armor)
    {
        this.Armor = Armor;
    }

    public ArmorSaveData Export()
    {
        return null;
        /*
        return new ArmorSaveData 
        {
            ArmorManagerComponentStorageSaveData = ArmorManager.StorageComponent.Export(),
            ArmorManagerComponentCurrencySaveData = ArmorManager.CurrencyComponent.Export()
        };
        */
    }
}
