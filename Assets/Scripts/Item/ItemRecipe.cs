public class ItemRecipe : Item
{
    public ItemComponentRecipe RecipeComponent;

    public ItemRecipe(ItemRecipeData data) : base(data)
    {
        RecipeComponent = new ItemComponentRecipe(data);
    }
}
