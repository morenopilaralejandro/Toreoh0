using Aremoreno.Enums.Item;

public static class ItemFactory
{
    public static Item Create(ItemData data) 
    {
        switch(data)
        {
            case ItemDataMaterial itemDataMaterial:
                return new ItemMaterial(itemDataMaterial);
            case ItemDataMisc itemDataMisc:
                return new ItemMisc(itemDataMisc);
            case ItemDataImportant itemDataImportant:
                return new ItemImportant(itemDataImportant);
            case ItemDataRecovery itemDataRecovery:
                return new ItemRecovery(itemDataRecovery);
            case ItemDataRecipe itemDataRecipe:
                return new ItemRecipe(itemDataRecipe);
            case ItemDataCharacter itemDataCharacter:
                return new ItemCharacter(itemDataCharacter);
            case ItemDataMove itemDataMove:
                return new ItemMove(itemDataMove);
            case ItemDataWing itemDataWing:
                return new ItemWing(itemDataWing);
            case ItemDataWeapon itemDataWeapon:
                return new ItemWeapon(itemDataWeapon);
            case ItemDataArmor itemDataArmor:
                return new ItemArmor(itemDataArmor);
            default:
                return null;
        }
    }

    public static Item CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.ItemData.Get(id));
}
