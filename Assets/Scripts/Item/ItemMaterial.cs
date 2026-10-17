public class ItemMaterial : Item
{
    public ItemComponentMaterial MaterialComponent;

    public ItemMaterial(ItemDataMaterial data) : base(data)
    {
        MaterialComponent = new ItemComponentMaterial(data);
    }
}
