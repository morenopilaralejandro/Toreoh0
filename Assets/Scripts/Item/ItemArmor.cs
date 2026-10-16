public class ItemArmor : Item
{
    public ItemComponentArmor ArmorComponent;

    public ItemArmor(ItemArmorData data) : base(data)
    {
        ArmorComponent = new ItemComponentArmor(data);
    }
}
