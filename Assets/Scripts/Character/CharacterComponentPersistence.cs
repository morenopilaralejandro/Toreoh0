public class CharacterComponentPersistence
{
    private Character character;

    public CharacterComponentPersistence(Character character)
    {
        this.character = character;
    }

    public CharacterSaveData Export()
    {
        return null;
        /*
        return new CharacterSaveData 
        {
            CharacterManagerComponentStorageSaveData = CharacterManager.StorageComponent.Export(),
            CharacterManagerComponentCurrencySaveData = CharacterManager.CurrencyComponent.Export()
        };
        */
    }
}
