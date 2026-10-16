public class ItemMaterial : Item
{
    public ItemComponentMaterial MaterialComponent;

    public ItemMaterial(ItemMaterialData data) : base(data)
    {
        MaterialComponent = new ItemComponentMaterial(data);
    }
}
