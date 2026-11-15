public static class CharacterFactory
{
    public static Character Create(CharacterData data, CharacterSaveData saveData = null) => new Character(data, saveData);
    public static Character CreateById(string id, CharacterSaveData saveData = null) => Create(DatabaseManager.Instance.DatabaseRegistry.CharacterData.Get(id), saveData);
   // public static Character CreateBySaveData(CharacterSaveData saveData) => Create(DatabaseManager.Instance.DatabaseRegistry.CharacterData.Get(id), saveData);
}
