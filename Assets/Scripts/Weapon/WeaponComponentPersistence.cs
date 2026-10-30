public class WeaponComponentPersistence
{
    private Weapon Weapon;

    public WeaponComponentPersistence(Weapon Weapon)
    {
        this.Weapon = Weapon;
    }

    public WeaponSaveData Export()
    {
        return null;
        /*
        return new WeaponSaveData 
        {
            WeaponManagerComponentStorageSaveData = WeaponManager.StorageComponent.Export(),
            WeaponManagerComponentCurrencySaveData = WeaponManager.CurrencyComponent.Export()
        };
        */
    }
}
