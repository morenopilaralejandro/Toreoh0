public class Weapon 
{
    public WeaponComponentAttributes WeaponComponentAttributes;
    public WeaponComponentPersistence WeaponComponentPersistence;

    public Weapon(WeaponData data)
    {
        WeaponComponentAttributes = new WeaponComponentAttributes(data);
        WeaponComponentPersistence = new WeaponComponentPersistence(this);
    }
}
