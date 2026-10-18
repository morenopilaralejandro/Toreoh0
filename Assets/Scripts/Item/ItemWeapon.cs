public class ItemWeapon : Item
{
    public ItemComponentWeapon WeaponComponent;

    public ItemWeapon(ItemDataWeapon data) : base(data)
    {
        WeaponComponent = new ItemComponentWeapon(data);
    }
}
