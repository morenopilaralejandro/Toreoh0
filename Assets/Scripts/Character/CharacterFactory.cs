public static class CharacterFactory
{
    public static Character Create(CharacterData data) => new Character(data);
    public static Character CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.CharacterData.Get(id));
}
