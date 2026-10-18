public class ItemRecipe : Item
{
    public ItemComponentRecipe RecipeComponent;

    public ItemRecipe(ItemDataRecipe data) : base(data)
    {
        RecipeComponent = new ItemComponentRecipe(data);
    }
}
