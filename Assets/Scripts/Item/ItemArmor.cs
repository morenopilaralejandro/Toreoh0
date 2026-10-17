public class ItemArmor : Item
{
    public ItemComponentArmor ArmorComponent;

    public ItemArmor(ItemDataArmor data) : base(data)
    {
        ArmorComponent = new ItemComponentArmor(data);
    }
}
