public class ItemWeapon : Item
{
    public ItemComponentWeapon WeaponComponent;

    public ItemWeapon(ItemWeaponData data) : base(data)
    {
        WeaponComponent = new ItemComponentWeapon(data);
    }
}
