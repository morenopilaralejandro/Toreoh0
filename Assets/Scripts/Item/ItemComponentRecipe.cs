public class ItemComponentRecipe
{
    public string ReferenceId;

    public ItemComponentInventory(ItemRecipeData data) 
    {
        ReferenceId = data.ReferenceId;
    }
}
