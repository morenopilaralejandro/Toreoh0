public static class WeaponFactory
{
    public static Weapon Create(WeaponData data) => new Weapon(data);
    public static Weapon CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.WeaponData.Get(id));
}
